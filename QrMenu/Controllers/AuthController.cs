using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QrMenu.Services.Auth;
using QrMenu.ViewModels.Auth;
using QrMenu.ViewModels.User;

namespace QrMenu.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authenticatorService;

        public AuthController(IAuthService authenticatorService)
        {
            this.authenticatorService = authenticatorService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest model)
        {
            var result = await authenticatorService.Login(model.Username, model.Password);

            if (result is null) return BadRequest("Invalid credentials");
            else return Ok(result);
        }

        [AllowAnonymous]
        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserRegisterRequest userRegister)
        {
            var result = await authenticatorService.Register(userRegister);

            if (result == null) return BadRequest();

            return Ok(result);
        }

        [AllowAnonymous]
        [Route("confirm-email")]
        [HttpPost]
        public async Task<IActionResult> ConfirmEmail([FromBody] ConfirmCodeRequest confirmCode)
        {
            var result = await authenticatorService.ConfirmUserEmail(confirmCode);

            if (!result) return BadRequest();

            return Ok(result);
        }

    }
}

