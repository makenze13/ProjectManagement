using Microsoft.AspNetCore.Identity;
using ProjectManagement.Models;
using ProjectManagement.Models.DTOs;
using ProjectManagement.Repositories;
using ProjectManagement.Repositories.Intefaces;
using ProjectManagement.Services.Interfaces;

namespace ProjectManagement.Services
{
    public class AuthService (IUserRepository userRepository, IPasswordHasher<User> passwordHasher,
                              IJwtService jwtService) : IAuthService
    {
        public async Task<string?> LoginAsync(UserLoginDto dto)
        {
            var user = await userRepository.GetUserByLoginAsync(dto.Login);

            if (user == null)
                return null;

            var result = passwordHasher.VerifyHashedPassword(
                user,
                user.Password,
                dto.Password);

            if (result == PasswordVerificationResult.Failed)
                return null;

            return jwtService.GenerateToken(user);
        }
    }
}
