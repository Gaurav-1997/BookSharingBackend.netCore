using BookSharing.Models;
using BookSharing.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSharing.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IAuthenticateService _authenticateService;
        public AuthenticateController(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }

        [HttpPost]
        public IActionResult Login([FromBody] User userModel)
        {
            var user = _authenticateService.Authenticate(userModel.UserName, userModel.UserPassword);

            if (user == null)
            {
                return BadRequest(new { message = " Incorrect uname or password." });
            }

            return Ok(user);
        }
    }
}
