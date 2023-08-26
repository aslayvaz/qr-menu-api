using Microsoft.AspNetCore.Mvc;
using QrMenu.Models;
using QrMenu.Services;
using QrMenu.ViewModels.User;

namespace QrMenu.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var user = await userService.GetUserById(id);

            if (user is null) return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] UserInsert user)
        {
            var result = await userService.AddUser(user);

            if (!result) return BadRequest();

            return Ok(true);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] User user)
        {
            var result = await userService.UpdateUser(id, user);

            if (!result) return NotFound();

            return Ok(true);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(string id)
        {
            var result = await userService.RemoveUser(id);

            if (!result) return NotFound();

            return Ok(true);
        }
    }
}

