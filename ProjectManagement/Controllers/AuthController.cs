using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Models.DTOs;
using ProjectManagement.Services;
using ProjectManagement.Services.Interfaces;

namespace ProjectManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto dto)
        {
            var token = await authService.LoginAsync(dto);

            if (token is null)
                return Unauthorized(new
                {
                    message = "Invalid login or password"
                });

            return Ok(new
            {
                accessToken = token,
                tokenType = "Bearer"
            });
        }
    }
}
