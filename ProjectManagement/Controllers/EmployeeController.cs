using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Models;

namespace ProjectManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController(ProjectManagementContext context) : Controller
    {
        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetEmployee()
        {
            var employees = await context.Employees.ToListAsync();

            return Ok(employees);
        }
    }
}
