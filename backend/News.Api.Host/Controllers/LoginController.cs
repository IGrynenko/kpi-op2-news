using Microsoft.AspNetCore.Mvc;
using New.Api.Core.Interfaces;
using New.Api.Core.Models;

namespace News.Api.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserDto>> ValidateUser([FromBody] UserModel model)
        {
            var token = await _loginService.LoginUser(model.Login, model.Password);

            if (token == null)
                return NotFound("Invalid credentials");

            return Ok(token);
        }
    }
}
