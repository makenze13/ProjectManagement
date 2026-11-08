using ProjectManagement.Models.DTOs;

namespace ProjectManagement.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<UserGetDto>> GetAllUsersAsync();
        Task<UserGetDto?> GetIdUserAsync(int id);
        Task<bool> DeleteUserAsync(int id);
    }
}