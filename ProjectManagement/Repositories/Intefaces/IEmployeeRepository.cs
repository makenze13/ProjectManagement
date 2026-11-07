using ProjectManagement.Models;
using ProjectManagement.Models.DTOs;

namespace ProjectManagement.Repositories.Intefaces
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllEmployeesAsync();
        Task<Employee?> GetIdEmployeeAsync(int id);
        Task<Employee?> AddEmployeeAsync(EmployeeCreateUpdateDto employee);
        Task<bool?> UpdateEmployeeAsync(EmployeeCreateUpdateDto employee, int id);
        Task<bool> DeleteEmployeeAsync(int id);
        Task<bool> CheckEmail(string email, int? id = null);
    }
}
