using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineMarks.Data.ViewModels.Auth;
using OnlineMarks.Data.ViewModels.Users;
using OnlineMarks.Interfaces.Services;
using OnlineMarks.Tools.Enums;

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

        [Authorize(Roles = UserRole.Admin)]
        [HttpGet]
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
    }
}
