using ProjectManagement.Models;
using ProjectManagement.Models.DTOs;

namespace ProjectManagement.Services.Interfaces
{
    public interface ITaskService
    {
        Task<List<ProjectTask>> GetAllProjectsTasksAsync();
        Task<ProjectTask?> GetIdProjectTaskAsync(int id);
        Task<ProjectTask?> AddProjectTaskAsync(ProjectTaskDto task);
        Task<bool> UpdateProjectTaskAsync(ProjectTaskDto task, int id);
        Task<bool> DeleteProjectTaskAsync(int id);
        Task<bool> UpdateStatusProjectTaskAsync(int id, ProjectTaskStatusDto status);
        Task<List<ProjectTask>> GetFilterProjectsTasksAsync(string? status, int? idProject, int? idEmployee);
        Task<List<CounterTasksInProjectDto>> GetCountTasksInProjectAsync();
        Task<ProjectTaskStatistics> GetStatisticsProjectsTasksAsync();
    }
}
