using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController(DataContext Context):ControllerBase
    {
        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetAuth()
        {
            return "secret text";
        }
        [HttpGet("not-found")]
        public ActionResult<AppUser> GetNotFound()
        {
            var thing = Context.Users.Find(-1);
            if (thing == null) return NotFound();
            return thing;
        }
        [HttpGet("server-error")]
        public ActionResult<AppUser> GetServerError()
        {
            var thing = Context.Users.Find(-1) ?? throw new Exception("a bad thing has happened");
            return thing;
        }
        [HttpGet("bad-request")]
        public ActionResult<AppUser> GetBadRequest()
        {
           
            return BadRequest("this was not a good request");
        }

    }
}
