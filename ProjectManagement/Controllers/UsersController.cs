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
            
            return Ok(user);
        }

        [HttpPost] 
        public async Task<ActionResult> AddUserAsync(UserAddDto userAddDto)
        {
            var newUser = await userService.AddUserAsync(userAddDto);

            if (newUser == null)
                return BadRequest();

            UserGetDto user = new UserGetDto
            {
                IdUser = newUser.IdUser,
                Login = newUser.Login,
                Role = newUser.Role,
                IdEmployee = newUser.IdEmployee
            };

            return CreatedAtAction(nameof(GetIdUserAsync), new { id = user.IdUser }, user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUserAsync(UserUpdateDto userUpdateDto, int id)
        {
            bool checkUpdate = await userService.UpdateUserAsync(userUpdateDto, id);

            if (checkUpdate)
                return NoContent();
            else
                return NotFound();
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
