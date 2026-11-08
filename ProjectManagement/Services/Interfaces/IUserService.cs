using ProjectManagement.Models;
using ProjectManagement.Models.DTOs;

namespace ProjectManagement.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<UserGetDto>> GetAllUsersAsync();
        Task<UserGetDto?> GetIdUserAsync(int id);
        Task<bool> DeleteUserAsync(int id);
        Task<User?> AddUserAsync(UserAddDto userDto);
        Task<bool> UpdateUserAsync(UserUpdateDto userUpdateDto, int id);
        public string HashUserPassword(string password);
        Task<bool> CheckLoginAsync(string login, int? id);
    }
}