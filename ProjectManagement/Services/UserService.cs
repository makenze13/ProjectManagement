using ProjectManagement.Models.DTOs;
using ProjectManagement.Repositories.Intefaces;
using ProjectManagement.Services.Interfaces;

namespace ProjectManagement.Services
{
    public class UserService(IUserRepository userRepository) : IUserService
    {
        public async Task<List<UserGetDto>> GetAllUsersAsync()
        {
            return await userRepository.GetAllUsersAsync();
        }

        public async Task<UserGetDto?> GetIdUserAsync(int id)
        {
            return await userRepository.GetIdUserAsync(id);
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            return await userRepository.DeleteUserAsync(id);
        }
    }
}
