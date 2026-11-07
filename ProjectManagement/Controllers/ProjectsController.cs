using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Models;
using ProjectManagement.Models.DTOs;
using ProjectManagement.Repositories.Intefaces;
using ProjectManagement.Services.Interfaces;

namespace ProjectManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController(IProjectService projectService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Project>>> GetProjectsAsync()
        {
            var projects = await projectService.GetAllProjectsAsync();

            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetIdProjectAsync(int id)
        {
            var project = await projectService.GetIdProjectAsync(id);

            if (project == null)
                return NotFound();

            return Ok(project);
        }

        [HttpPost]
        public async Task<ActionResult> AddProjectAsync([FromBody] ProjectDto project)
        {
            var newProject = await projectService.AddProjectAsync(project);

            return CreatedAtAction(nameof(GetIdProjectAsync), new { id = newProject.IdProject }, newProject);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProjectAsync([FromBody] ProjectDto project, int id)
        {
            bool checkUpdate = await projectService.UpdateProjectAsync(project, id);

            if (checkUpdate)
                return NoContent();
            else
                return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProjectAsync(int id)
        {
            var delete = await projectService.DeleteProjectAsync(id);

            if (delete == null)
                return BadRequest();
            else if (delete == true)
                return NoContent();
            else
                return NotFound();
        }
    }
}
