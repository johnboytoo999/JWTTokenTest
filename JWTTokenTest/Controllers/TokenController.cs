using JWTTokenTest.Helpers;
using JWTTokenTest.Models;
using JWTTokenTest.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace JWTTokenTest.Controllers
{
    [Authorize]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly JwtHelpers jwt;
        private readonly ITokenservice tokenservice;
        public TokenController(JwtHelpers jwt, ITokenservice tokenservice)
        {
            this.jwt = jwt;
            this.tokenservice = tokenservice;
        }


        [AllowAnonymous]
        [HttpPost("~/signin")]
        public ActionResult<string> ValidUser(LoginViewModel login)
        {
            if (tokenservice.ValidUser(login))
            {
                return jwt.GenerateToken(login.Username);
            }
            else
            {
                return BadRequest();
            }
        }

        private bool ValidateUser(LoginViewModel login)
        {
            return true; // TODO
        }

        [Authorize]
        [HttpGet("~/claims")]
        public IActionResult GetClaims()
        {
            return Ok(User.Claims.Select(p => new { p.Type, p.Value }));
        }


        [Authorize]
        [HttpGet("~/username")]
        public IActionResult GetUserName()
        {
            return Ok(User.Identity.Name);
        }

        [HttpGet("~/jwtid")]
        public IActionResult GetUniqueId()
        {
            var jti = User.Claims.FirstOrDefault(p => p.Type == "jti");
            return Ok(jti.Value);
        }
    }

    
}

