using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Models;
using ProjectManagement.Models.DTOs;
using ProjectManagement.Repositories.Intefaces;

namespace ProjectManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController(IProjectRepository projectRepository) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Project>>> GetProjectsAsync()
        {
            var projects = await projectRepository.GetAllProjectsAsync();

            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetIdProjectAsync(int id)
        {
            var project = await projectRepository.GetIdProjectAsync(id);

            if (project == null)
                return NotFound();

            return Ok(project);
        }

        [HttpPost]
        public async Task<ActionResult> AddProjectAsync([FromBody] ProjectDto project)
        {
            var newProject = await projectRepository.AddProjectAsync(project);

            return CreatedAtAction(nameof(GetIdProjectAsync), new { id = newProject.IdProject }, newProject);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProjectAsync([FromBody] ProjectDto project, int id)
        {
            bool checkUpdate = await projectRepository.UpdateProjectAsync(project, id);

            if (checkUpdate)
                return NoContent();
            else
                return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProjectAsync(int id)
        {
            if (await projectRepository.DeleteProjectAsync(id))
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
