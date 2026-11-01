using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.Models.DTOs
{
    public class EmployeeCreateUpdateDto
    {
        [Required(ErrorMessage = "Имя сотрудника обязательно")]
        public string Fullname { get; set; }

        [Required(ErrorMessage = "Email обязателен")]
        [EmailAddress(ErrorMessage = "Некорректный формат Email")]
        public string Email { get; set; }
    }
}
