using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.Models.DTOs
{
    public class ProjectTaskDto
    {
        [Required(ErrorMessage = "Название задачи обязательно")]
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }

        [Required(ErrorMessage = "Задача должна принадлежать проекту!")]
        public int IdProject { get; set; }
        public int? IdEmployee { get; set; }
    }
}
