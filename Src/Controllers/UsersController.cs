using Microsoft.AspNetCore.Mvc;
using users_api.Src.DTO;
using users_api.Src.Services.interfaces;

namespace users_api.Src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController(IUserService userService) : Controller
    {
        private readonly IUserService _userService = userService;

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