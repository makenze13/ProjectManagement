namespace ProjectManagement.Models.DTOs
{
    public class ProjectTaskStatusDto
    {
        public TaskStatus TaskStatus { get; set; }
    }

    public enum TaskStatus
    {
        New,
        InProgress,
        Completed,
        Cancelled
    }
}
