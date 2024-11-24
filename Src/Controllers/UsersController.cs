using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using users_api.Src.DTO;
using users_api.Src.Services.interfaces;

namespace users_api.Src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsersController(IUserService userService) : Controller
    {
        private readonly IUserService _userService = userService;

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            var user = await _userService.GetUser(id);
            return user != null ? Ok(user) : NotFound();
        }

        [HttpGet()]
        public async Task<IActionResult> GetUsers([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var users = await _userService.GetUsers(pageNumber, pageSize);
            return Ok(users);
        }

        [HttpPost()]
        public async Task<IActionResult> CreateUser(CreateUserDto createUser)
        {
            try {
                var user = await _userService.CreateUser(createUser);
                return Created($"/api/users/{user.Id}", user);
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, EditUserDto editUser)
        {
            try {
                var result = await _userService.UpdateUser(id, editUser);
                return result ? NoContent() : NotFound();
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var result = await _userService.DeleteUser(id);
            return result ? NoContent() : NotFound();
        }
    }
}