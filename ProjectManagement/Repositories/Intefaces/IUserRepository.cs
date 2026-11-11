using ProjectManagement.Models;
using ProjectManagement.Models.DTOs;

namespace ProjectManagement.Repositories.Intefaces
{
    public interface IUserRepository
    {
        Task<List<UserGetDto>> GetAllUsersAsync();
        Task<UserGetDto?> GetIdUserAsync(int id);
        Task<User?> GetFullUserDataAsync(int id);
        Task<bool> DeleteUserAsync(int id);
        Task<User?> AddUserAsync(UserAddDto userDto, string hash);
        Task UpdateUserAsync(UserUpdateDto userDto, User? user, string? hash);
        Task<bool> LoginExistsAsync(string login, int? id);
        Task<User?> GetUserByLoginAsync(string login);
    }
}