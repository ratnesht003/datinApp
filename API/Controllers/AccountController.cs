﻿using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace API.Controllers;

public class AccountController(DataContext context,ITokenService tokenService): ControllerBase
{
    [HttpPost("register")]
    public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
    {
        if(await UserExists(registerDto.Username))
        {
            return BadRequest("Username is taken");
        }
        using var hmac = new HMACSHA512();
        var user = new AppUser
        {
            UserName = registerDto.Username.ToLower(),
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
            passwordSalt = hmac.Key
        };
        context.Users.Add(user);
        await context.SaveChangesAsync();
        return new UserDto
        {
            Username = user.UserName,
            Token = tokenService.CreateToken(user)
        };
    }
    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
    {
        var user = await context.Users.
            FirstOrDefaultAsync(x => x.UserName == loginDto.Username.ToLower());
        if(user == null)
        {
            return Unauthorized("invalid user");
        }
        using var hmac=new HMACSHA512(user.passwordSalt);
        var computeHash=hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));
        for(int i=0;i<computeHash.Length;i++)
        {
            if (computeHash[i] != user.PasswordHash[i])
            {
                return Unauthorized("invalid password");
            }
           
        }
        return new UserDto
        {
            Username = user.UserName,
            Token = tokenService.CreateToken(user)
        };
    }
    private async Task<bool> UserExists(string username)
    {
        return await context.Users.AnyAsync(x=>x.UserName.ToLower() == username.ToLower());
    }
}
