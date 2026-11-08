using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Models.DTOs;
using ProjectManagement.Services.Interfaces;

namespace ProjectManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserService userService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<UserGetDto>>> GetAllUsersAsync()
        {
            var users = await userService.GetAllUsersAsync();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserGetDto>> GetIdUserAsync(int id)
        {
            var user = await userService.GetIdUserAsync(id);

            if (user == null)
                return NotFound();
            else
                return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserAsync(int id)
        {
            if (await userService.DeleteUserAsync(id))
                return NoContent();
            else
                return NotFound();
        }
    }
}
