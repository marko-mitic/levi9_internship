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

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [AllowAnonymous]
        [HttpGet("authenticate")]
        public IActionResult Authenticate([FromBody]AutheticateModel model)
        {
            var users = _userService.Authenticate(model);
            return Ok(users);
        }

        /*[AllowAnonymous]
        [HttpGet("id")]
        public IActionResult Get([FromBody] AutheticateModel model)
        {
            var user = _userService.GetById();
            return Ok(user);
        }*/

        [AllowAnonymous]
        [HttpPost]

        public IActionResult Add([FromBody] AutheticateModel model)
        {
            _userService.Add(model.Username, model.Password);
            return Ok("You have successfully added " + model.Username);
        }
    }
}
