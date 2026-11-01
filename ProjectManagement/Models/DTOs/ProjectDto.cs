using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.Models.DTOs
{
    public class ProjectDto
    {
        [Required(ErrorMessage = "Название проекта обязательно")]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }
    }
}
