using Microsoft.EntityFrameworkCore;
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
    }
}
