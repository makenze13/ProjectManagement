using Microsoft.AspNetCore.Identity;
using ProjectManagement.Models;
using ProjectManagement.Models.DTOs;
using ProjectManagement.Repositories.Intefaces;
using ProjectManagement.Services.Interfaces;

namespace ProjectManagement.Services
{
    public class UserService(IUserRepository userRepository, IPasswordHasher<User> passwordHasher) : IUserService
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

        public async Task<User?> AddUserAsync(UserAddDto userDto)
        {
            var checkLogin = await CheckLoginAsync(userDto.Login, null);

            if (!checkLogin)
                return null;

            var hash = HashUserPassword(userDto.Password);

            return await userRepository.AddUserAsync(userDto, hash);
        }

        public async Task<bool> UpdateUserAsync(UserUpdateDto userUpdateDto, int id)
        {
            var checkLogin = await CheckLoginAsync(userUpdateDto.Login, id);

            if (!checkLogin)
                return false;

            var user = await CheckUserPasswordAsync(userUpdateDto, id);

            if (user == null)
                return false;

            string? hash;

            if (string.IsNullOrWhiteSpace(userUpdateDto.NewPassword))
                hash = null;
            else
                hash = HashUserPassword(userUpdateDto.NewPassword);

            await userRepository.UpdateUserAsync(userUpdateDto, user, hash);

            return true;
        }

        public async Task<User?> CheckUserPasswordAsync(UserUpdateDto userDto, int id)
        {
            var user = await userRepository.GetFullUserDataAsync(id);

            if (user == null)
                return null;

            if (string.IsNullOrWhiteSpace(userDto.Password))
                return null;

            var check = passwordHasher.VerifyHashedPassword(user, user.Password, userDto.Password);

            if (check == PasswordVerificationResult.Success || check == PasswordVerificationResult.SuccessRehashNeeded)
                return user;
            else
                return null;
        }

        public string HashUserPassword(string password)
        {
            return passwordHasher.HashPassword(new User(), password);
        }

        public async Task<bool> CheckLoginAsync(string login, int? id)
        {
            var checkLogin = await userRepository.LoginExistsAsync(login);

            if (checkLogin == null)
                return true;
            else
                return false;
        }
    }
}
