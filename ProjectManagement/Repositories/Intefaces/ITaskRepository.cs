using ProjectManagement.Models;
using ProjectManagement.Models.DTOs;

namespace ProjectManagement.Repositories.Intefaces
{
    public interface ITaskRepository
    {
        Task<List<ProjectTask>> GetAllProjectsTasksAsync();
        Task<ProjectTask?> GetIdProjectTaskAsync(int id);
        Task<ProjectTask?> AddProjectTaskAsync(ProjectTaskDto task);
        Task<bool> UpdateProjectTaskAsync(ProjectTaskDto task, int id);
        Task<bool> DeleteProjectTaskAsync(int id);
        Task<bool> UpdateStatusProjectTaskAsync(int id, ProjectTaskStatusDto status);
        Task<bool> CheckExistEmployeeAsync(int id);
        Task<bool> CheckExistProjectAsync(int id);
        Task<bool> CheckCorrectDateAsync(DateTime dueDate, int? id = null);
        Task<List<ProjectTask>> GetFilterProjectsTasksAsync(string? status = null, int? idProject = null, int? idEmployee = null);
    }
}
