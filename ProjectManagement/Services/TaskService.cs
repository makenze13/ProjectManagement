using Microsoft.EntityFrameworkCore;
using ProjectManagement.Models;
using ProjectManagement.Models.DTOs;
using ProjectManagement.Repositories.Intefaces;
using ProjectManagement.Services.Interfaces;

namespace ProjectManagement.Services
{
    public class TaskService(ITaskRepository taskRepository) : ITaskService
    {
        public async Task<List<ProjectTask>> GetAllProjectsTasksAsync()
        {
            return await taskRepository.GetAllProjectsTasksAsync();
        }

        public async Task<ProjectTask?> GetIdProjectTaskAsync(int id)
        {
            return await taskRepository.GetIdProjectTaskAsync(id);
        }

        public async Task<ProjectTask?> AddProjectTaskAsync(ProjectTaskDto taskDto)
        {
            if(!await CheckIdEmployeeAndProjectAsync(taskDto.IdProject, taskDto.IdEmployee))
                return null;

            if (taskDto.DueDate.HasValue && await taskRepository.CheckCorrectDateAsync((DateTime)taskDto.DueDate))
                return null;

            return await taskRepository.AddProjectTaskAsync(taskDto);
        }

        public async Task<bool> UpdateProjectTaskAsync(ProjectTaskDto task, int id)
        {
            if (!await CheckIdEmployeeAndProjectAsync(task.IdProject, task.IdEmployee))
                return false;

            if (task.DueDate.HasValue && await taskRepository.CheckCorrectDateAsync((DateTime)task.DueDate, id))
                return false;

            return await taskRepository.UpdateProjectTaskAsync(task, id);
        }

        public async Task<bool> DeleteProjectTaskAsync(int id)
        {
            return await taskRepository.DeleteProjectTaskAsync(id);
        }

        public async Task<bool> UpdateStatusProjectTaskAsync(int id, ProjectTaskStatusDto status)
        {
            return await taskRepository.UpdateStatusProjectTaskAsync(id, status);
        }

        private async Task<bool> CheckIdEmployeeAndProjectAsync(int? idProject, int? idEmployee)
        {
            if (idProject != null)
            {
                if (!await taskRepository.CheckExistProjectAsync((int)idProject))
                    return false;
            }

            if (idEmployee != null)
            {
                if (!await taskRepository.CheckExistEmployeeAsync((int)idEmployee))
                    return false;
            }

            return true;
        }
    }
}
