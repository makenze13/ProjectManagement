using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Models;
using ProjectManagement.Models.DTOs;
using ProjectManagement.Services;

namespace ProjectManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeesController(IEmployeeService employeeService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetEmployeesAsync()
        {
            var employees = await employeeService.GetAllEmployeeAsync();

            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetIdEmployeeAsync(int id)
        {
            var employee = await employeeService.GetIdEmployeeAsync(id);

            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult> AddEmployeeAsync([FromBody] EmployeeCreateUpdateDto employee)
        {
            var newEmployee = await employeeService.AddEmployeeAsync(employee);

            if (newEmployee == null)
                return Conflict();

            return CreatedAtAction(nameof(GetIdEmployeeAsync), new { id = newEmployee.IdEmployee}, newEmployee);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEmployeeAsync([FromBody] EmployeeCreateUpdateDto employee, int id)
        {
            bool checkUpdate = await employeeService.UpdateEmployeeAsync(employee, id);

            if (checkUpdate)
                return NoContent();
            else 
                return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployeeAsync(int id)
        {
            if (await employeeService.DeleteEmployeeAsync(id))
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
