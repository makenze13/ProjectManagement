using ProjectManagement.Models;
using ProjectManagement.Models.DTOs;
using ProjectManagement.Repositories.Intefaces;
using ProjectManagement.Services.Interfaces;

namespace ProjectManagement.Services
{
    public class ProjectService(IProjectRepository projectRepository) : IProjectService
    {
        public async Task<List<Project>> GetAllProjectsAsync()
        {
            return await projectRepository.GetAllProjectsAsync();
        }

        public async Task<Project?> GetIdProjectAsync(int id)
        {
            return await projectRepository.GetIdProjectAsync(id);
        }

        public async Task<Project?> AddProjectAsync(ProjectDto project)
        {
            return await projectRepository.AddProjectAsync(project);
        }

        public async Task<bool> UpdateProjectAsync(ProjectDto project, int id)
        {
            return await projectRepository.UpdateProjectAsync(project, id);
        }

        public async Task<bool?> DeleteProjectAsync(int id)
        {
            return await projectRepository.DeleteProjectAsync(id);
        }
    }
}
