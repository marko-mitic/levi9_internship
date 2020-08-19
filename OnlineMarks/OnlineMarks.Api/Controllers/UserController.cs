using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineMarks.Data.ViewModels.Auth;
using OnlineMarks.Data.ViewModels.Users;
using OnlineMarks.Interfaces.Services;
using OnlineMarks.Tools.Enums;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace OnlineMarks.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]AuthenticateModel model)
        {
            var users = _userService.Authenticate(model);
            return Ok(users);
        }

        [Authorize(Roles = UserRole.Admin)]
        [HttpPost("add")]
        public IActionResult Add([FromBody] AuthenticateModel model)
        {
            _userService.Add(model.Username, model.Password, model.Role);
            return Ok("You have successfully added " + model.Username + "!");
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity.Name == null)
            {
                return NotFound("Identity not found!");
            }
            var user = _userService.GetById(Guid.Parse(identity.Name));
            return Ok(user);
        }
    }
}
