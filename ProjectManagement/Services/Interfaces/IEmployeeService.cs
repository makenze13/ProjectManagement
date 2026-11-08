using ProjectManagement.Models;
using ProjectManagement.Models.DTOs;

namespace ProjectManagement.Services
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllEmployeeAsync();
        Task<Employee?> GetIdEmployeeAsync(int id);
        Task<Employee?> AddEmployeeAsync(EmployeeCreateUpdateDto employee);
        Task<bool> UpdateEmployeeAsync(EmployeeCreateUpdateDto employee, int id);
        Task<bool> DeleteEmployeeAsync(int id);
    }
}