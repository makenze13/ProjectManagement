using ProjectManagement.Models;
using ProjectManagement.Models.DTOs;

namespace ProjectManagement.Repositories.Intefaces
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllProjectsAsync();
        Task<Project?> GetIdProjectAsync(int id);
        Task<Project?> AddProjectAsync(ProjectDto project);
        Task<bool> UpdateProjectAsync(ProjectDto project, int id);
        Task<bool> DeleteProjectAsync(int id);
    }
}
