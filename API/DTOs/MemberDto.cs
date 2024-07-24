﻿using API.Entities;

namespace API.DTOs;

public class MemberDto
{
    public int Id { get; set; }
    public string? UserName { get; set; }
    public int age { get; set; }
    public string? PhotoUrl { get; set; }
    public required string KnonAs { get; set; }
    public DateTime Created { get; set; }
    public DateTime LastActive { get; set; } 
    public string? gender { get; set; }
    public string? Introduction { get; set; }
    public string? Intrestes { get; set; }
    public string? LookingFor { get; set; }
    public string? city { get; set; }
    public  string? country { get; set; }
    public List<PhotoDto> Photos { get; set; }
}
