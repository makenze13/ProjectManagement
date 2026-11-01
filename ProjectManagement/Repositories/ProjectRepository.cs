using Microsoft.EntityFrameworkCore;
using ProjectManagement.Models;
using ProjectManagement.Models.DTOs;
using ProjectManagement.Repositories.Intefaces;

namespace ProjectManagement.Repositories
{
    public class ProjectRepository(ProjectManagementContext context) : IProjectRepository
    {
        public async Task <List<Project>> GetAllProjectsAsync()
        {
            return await context.Projects.ToListAsync();
        }

        public async Task<Project?> GetIdProjectAsync(int id)
        {
            return await context.Projects.FirstOrDefaultAsync(p => p.IdProject == id);
        }

        public async Task<Project?> AddProjectAsync(ProjectDto projectDto)
        {
            Project project = new Project
            {
                Name = projectDto.Name,
                Description = projectDto.Description 
            };

            await context.Projects.AddAsync(project);
            await context.SaveChangesAsync();

            return project;
        }

        public async Task<bool> UpdateProjectAsync(ProjectDto project, int id)
        {
            var currentProject = await context.Projects.FirstOrDefaultAsync(p => p.IdProject == id);

            if (currentProject != null)
            {
                currentProject.Name = project.Name;
                currentProject.Description = project.Description;

                await context.SaveChangesAsync();

                return true;
            }
            else
                return false;
        }

        public async Task<bool> DeleteProjectAsync(int id)
        {
            var project = await context.Projects.FirstOrDefaultAsync(p => p.IdProject == id);

            if (project != null)
            {
                context.Projects.Remove(project);
                await context.SaveChangesAsync();

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
