using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Trade.Domain.Entities;
using Trade.Domain.Interfaces.Services;

namespace Trade.Technology.Controllers
{
    [Authorize]
    [Route("users")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string email)
        {
            return Ok(await _userService.GetUser(email));
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            var existUser = await _userService.GetUser(user.Email);

            if (existUser is not null)
            {
                return BadRequest("User already exists.");
            }

            await _userService.Create(user);

            return Ok();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public IActionResult Login([FromBody] User user)
        {
            var token = _userService.Authenticate(user.Email, user.Password);

            if (token is null)
            {
                return Unauthorized();
            }

            return Ok(new { token, user });
        }


    }
}
