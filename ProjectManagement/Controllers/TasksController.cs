using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Models;
using ProjectManagement.Models.DTOs;
using ProjectManagement.Services.Interfaces;

namespace ProjectManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController(ITaskService taskService) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<List<ProjectTask>>> GetProjectsTasksAsync()
        {
            var tasks = await taskService.GetAllProjectsTasksAsync();

            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectTask>> GetIdProjectTaskAsync(int id)
        {
            var task = await taskService.GetIdProjectTaskAsync(id);

            if (task == null)
                return NotFound();

            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult> AddProjectTaskAsync([FromBody] ProjectTaskDto task)
        {
            var newTask = await taskService.AddProjectTaskAsync(task);

            if (newTask == null)
                return BadRequest();

            return CreatedAtAction(nameof(GetIdProjectTaskAsync), new { id = newTask.IdTask }, newTask);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProjectTaskAsync([FromBody] ProjectTaskDto task, int id)
        {
            bool checkUpdate = await taskService.UpdateProjectTaskAsync(task, id);

            if (checkUpdate)
                return NoContent();
            else
                return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProjectTaskAsync(int id)
        {
            if (await taskService.DeleteProjectTaskAsync(id))
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPatch("{id}/status")]
        public async Task<ActionResult> UpdateStatusProjectTaskAsync(int id, [FromBody] ProjectTaskStatusDto status)
        {
            bool checkUpdate = await taskService.UpdateStatusProjectTaskAsync(id, status);

            if (checkUpdate)
                return NoContent();
            else
                return NotFound();

        }
    }
}
