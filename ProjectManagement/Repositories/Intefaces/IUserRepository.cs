using ProjectManagement.Models.DTOs;

namespace ProjectManagement.Repositories.Intefaces
{
    public interface IUserRepository
    {
        Task<List<UserGetDto>> GetAllUsersAsync();
        Task<UserGetDto?> GetIdUserAsync(int id);
        Task<bool> DeleteUserAsync(int id);
    }
}