using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Models;
using ProjectManagement.Models.DTOs;
using ProjectManagement.Repositories.Intefaces;

namespace ProjectManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController(IEmployeeRepository employeeRepository) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetEmployee()
        {
            var employees = await employeeRepository.GetAllEmployeesAsync();

            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetIdEmployee(int id)
        {
            var employee = await employeeRepository.GetIdEmployeeAsync(id);

            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult> AddEmployeeAsync([FromBody] EmployeeCreateUpdateDto employee)
        {

            var newEmployee = await employeeRepository.AddEmployeeAsync(employee);

            if (newEmployee == null)
                return Conflict();

            return CreatedAtAction(nameof(GetIdEmployee), new { id = newEmployee.IdEmployee}, newEmployee);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEmployeeAsync([FromBody] EmployeeCreateUpdateDto employee, int id)
        {
            bool? checkUpdate = await employeeRepository.UpdateEmployeeAsync(employee, id);

            if (checkUpdate == true)
                return NoContent();
            else if (checkUpdate == false)
                return NotFound();
            else
                return Conflict();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployeeAsync(int id)
        {
            if (await employeeRepository.DeleteEmployeeAsync(id))
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
