using ProjectManagement.Models.DTOs;

namespace ProjectManagement.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string?> LoginAsync(UserLoginDto dto);
    }
}
