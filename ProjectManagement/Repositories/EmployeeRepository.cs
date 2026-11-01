using Microsoft.EntityFrameworkCore;
using ProjectManagement.Models;
using ProjectManagement.Models.DTOs;
using ProjectManagement.Repositories.Intefaces;

namespace ProjectManagement.Repositories
{
    public class EmployeeRepository(ProjectManagementContext context): IEmployeeRepository
    {
        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await context.Employees.ToListAsync();
        }

        public async Task<Employee?> GetIdEmployeeAsync(int id)
        {
            return await context.Employees.FirstOrDefaultAsync(e => e.IdEmployee == id);
        }

        public async Task<Employee?> AddEmployeeAsync(EmployeeCreateUpdateDto employeeDto)
        {
            Employee employee = new Employee
            {
                Fullname = employeeDto.Fullname,
                Email = employeeDto.Email
            };
            if (!await CheckEmail(employee.Email))
                return null;

            await context.Employees.AddAsync(employee);
            await context.SaveChangesAsync();

            return employee;
        }

        public async Task<bool?> UpdateEmployeeAsync(EmployeeCreateUpdateDto employee, int id)
        {
            var currentEmployee = await context.Employees.FirstOrDefaultAsync(e => e.IdEmployee == id);

            if (currentEmployee != null)
            {
                if (!await CheckEmail(employee.Email, id))
                    return null;

                currentEmployee.Fullname = employee.Fullname;
                currentEmployee.Email = employee.Email;

                await context.SaveChangesAsync();

                return true;
            }
            else
                return false;
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var employee = await context.Employees.FirstOrDefaultAsync(e => e.IdEmployee == id);

            if (employee != null)
            {
                context.Employees.Remove(employee);
                await context.SaveChangesAsync();

                return true;
            }
            else
            {
                return false;
            }
        }

        private async Task<bool> CheckEmail(string email, int? id = null)
        {
            var checkEmail = await context.Employees.FirstOrDefaultAsync(e => e.Email == email && (id == null || e.IdEmployee != id));

            if (checkEmail != null)
            {
                return false;
            }
            else
                return true;
        }
    }
}
