using ProjectManagement.Models;
using ProjectManagement.Models.DTOs;
using ProjectManagement.Repositories.Intefaces;

namespace ProjectManagement.Services
{
    public class EmployeeService(IEmployeeRepository employeeRepository) : IEmployeeService
    {
        public async Task<List<Employee>> GetAllEmployeeAsync()
        {
            return await employeeRepository.GetAllEmployeesAsync();
        }

        public async Task<Employee?> GetIdEmployeeAsync(int id)
        {
            return await employeeRepository.GetIdEmployeeAsync(id);
        }

        public async Task<Employee?> AddEmployeeAsync(EmployeeCreateUpdateDto employee)
        {
            if (!await employeeRepository.CheckEmail(employee.Email))
                return null;

            return await employeeRepository.AddEmployeeAsync(employee);
        }

        public async Task<bool?> UpdateEmployeeAsync(EmployeeCreateUpdateDto employee, int id)
        {
            if (!await employeeRepository.CheckEmail(employee.Email, id))
                return null;

            return await employeeRepository.UpdateEmployeeAsync(employee, id);
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            return await employeeRepository.DeleteEmployeeAsync(id);
        }
    }
}
