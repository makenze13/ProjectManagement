using ProjectManagement.Models;

namespace ProjectManagement.Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(User user); 
    }
}
