using ProjectManagement.Models;
using ProjectManagement.Models.DTOs;

namespace ProjectManagement.Services.Interfaces
{
    public interface IProjectService
    {
        Task<List<Project>> GetAllProjectsAsync();
        Task<Project?> GetIdProjectAsync(int id);
        Task<Project?> AddProjectAsync(ProjectDto projectDto);
        Task<bool> UpdateProjectAsync(ProjectDto project, int id);
        Task<bool?> DeleteProjectAsync(int id);
    }
}