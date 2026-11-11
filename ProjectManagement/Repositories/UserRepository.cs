using Microsoft.EntityFrameworkCore;
using ProjectManagement.Models;
using ProjectManagement.Models.DTOs;
using ProjectManagement.Repositories.Intefaces;

namespace ProjectManagement.Repositories
{
    public class UserRepository(ProjectManagementContext context) : IUserRepository
    {
        public async Task<List<UserGetDto>> GetAllUsersAsync()
        {
            return await context.Users.Select(u => new UserGetDto
            {
                IdUser = u.IdUser,
                Login = u.Login,
                Role = u.Role,
                IdEmployee = u.IdEmployee
            }).ToListAsync();
        }

        public async Task<UserGetDto?> GetIdUserAsync(int id)
        {
            return await context.Users
                .Where(u => u.IdUser == id)
                .Select(u => new UserGetDto
                {
                    IdUser = u.IdUser,
                    Login = u.Login,
                    Role = u.Role,
                    IdEmployee = u.IdEmployee
                })
                .FirstOrDefaultAsync();
        }

        public async Task<User?> GetFullUserDataAsync(int id)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.IdUser == id);
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.IdUser == id);

            if (user != null)
            {
                context.Users.Remove(user);
                await context.SaveChangesAsync();

                return true;
            }
            else
                return false;
        }

        public async Task<User?> AddUserAsync(UserAddDto userDto, string hash)
        {
            User user = new()
            {
                Login = userDto.Login,
                Role = userDto.Role,
                IdEmployee = userDto.IdEmployee,
                Password = hash
            };

            await context.Users.AddAsync(user);

            await context.SaveChangesAsync();
            
            return user;
        }

        public async Task UpdateUserAsync(UserUpdateDto userDto, User user, string? hash)
        {
            user.Login = userDto.Login;
            user.Role = userDto.Role;
            user.IdEmployee = userDto.IdEmployee;

            if (hash != null)
                user.Password = hash;

            await context.SaveChangesAsync();
        }

        public async Task<bool> LoginExistsAsync(string login, int? id)
        {
            return await context.Users.AnyAsync(u => u.Login == login && u.IdUser != id);
        }

        public async Task<User?> GetUserByLoginAsync(string login)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.Login == login);
        }
    }
}
