using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.ValueGeneration.Internal;
using ProjectManagement.Models;
using ProjectManagement.Models.DTOs;
using ProjectManagement.Repositories.Intefaces;

namespace ProjectManagement.Repositories
{
    public class TaskRepository(ProjectManagementContext context) : ITaskRepository
    {
        public async Task<List<ProjectTask>> GetAllProjectsTasksAsync()
        {
            return await context.Tasks.ToListAsync();
        }

        public async Task<ProjectTask?> GetIdProjectTaskAsync(int id)
        {
            return await context.Tasks.FirstOrDefaultAsync(t => t.IdTask == id);
        }

        public async Task<ProjectTask?> AddProjectTaskAsync(ProjectTaskDto taskDto)
        {
            ProjectTask task = new ProjectTask
            {
                DueDate = taskDto.DueDate,
                Description = taskDto.Description,
                Title = taskDto.Title,
                IdEmployee = taskDto.IdEmployee,
                IdProject = taskDto.IdProject
            };

            await context.Tasks.AddAsync(task);
            await context.SaveChangesAsync();

            return task;
        }

        public async Task<bool> UpdateProjectTaskAsync(ProjectTaskDto task, int id)
        {
            var currentTask = await context.Tasks.FirstOrDefaultAsync(t => t.IdTask == id);

            if (currentTask != null)
            {
                currentTask.Title = task.Title;
                currentTask.DueDate = task.DueDate;
                currentTask.Description = task.Description;
                currentTask.IdProject = task.IdProject;
                currentTask.IdEmployee = task.IdEmployee;

                await context.SaveChangesAsync();

                return true;
            }
            else
                return false;
        }

        public async Task<bool> DeleteProjectTaskAsync(int id)
        {
            var task = await context.Tasks.FirstOrDefaultAsync(t => t.IdTask == id);

            if (task != null)
            {
                context.Tasks.Remove(task);
                await context.SaveChangesAsync();

                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> UpdateStatusProjectTaskAsync(int id, ProjectTaskStatusDto status)
        {
            var currentTask = await context.Tasks.FirstOrDefaultAsync(t => t.IdTask == id);

            if(!Enum.IsDefined(status.TaskStatus))
                return false;

            if (currentTask != null)
            {
                currentTask.Status = status.TaskStatus.ToString();

                await context.SaveChangesAsync();

                return true;
            }
            else
                return false;
        }

        public async Task<bool> CheckExistEmployeeAsync(int id)
        {
            return await context.Employees.AnyAsync(e => e.IdEmployee == id);
        }

        public async Task<bool> CheckExistProjectAsync(int id)
        {
            return await context.Projects.AnyAsync(p => p.IdProject == id);
        }

        public async Task<bool> CheckCorrectDateAsync(DateTime dueDate, int? id = null)
        {
            DateTime currentDate;

            if (id != null)
            {
                var task = await context.Tasks.FirstOrDefaultAsync(t => t.IdTask == id);
                currentDate = task.CreatedAt.ToDateTime(TimeOnly.MinValue);
            }
            else
                currentDate = DateTime.Now;

            if (currentDate < dueDate)
                return false;
            else
                return true;
        }

        public async Task<List<ProjectTask>> GetFilterProjectsTasksAsync(string? status = null, int? idProject = null, int? idEmployee = null)
        {
            var tasks = context.Tasks.AsQueryable();

            if (status != null)
                tasks = tasks.Where(t => t.Status == status);

            if (idProject != null)
                tasks = tasks.Where(t => t.IdProject == idProject);

            if (idEmployee != null)
                tasks = tasks.Where(t => t.IdEmployee == idEmployee);

            return await tasks.ToListAsync();
        }
    }
}
