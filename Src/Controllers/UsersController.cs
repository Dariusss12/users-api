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

        [HttpGet("/{id}")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            try {
                var user = await _userService.GetUser(id);
                return user != null ? Ok(user) : NotFound();
            }
            catch (Exception e) {
                return StatusCode (500, e.Message);
            }
        }
        [HttpGet("/")]
        public async Task<IActionResult> GetUsers()
        {
            try {
                var users = await _userService.GetUsers();
                return Ok(users);
            }
            catch (Exception e) {
                return StatusCode (500, e.Message);
            }
        }
        [HttpPost("/create")]
        public async Task<IActionResult> CreateUser(CreateUserDto createUser)
        {
            try {
                var user = await _userService.CreateUser(createUser);
                return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user) : BadRequest();
            }
            catch (Exception e) {
                return StatusCode(500, e.Message);
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