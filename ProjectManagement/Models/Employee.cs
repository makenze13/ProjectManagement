namespace ProjectManagement.Models;

public partial class Employee
{
    public int IdEmployee { get; set; }

    public string Fullname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateOnly? CreatedAt { get; set; }

    public virtual ICollection<ProjectTask> Tasks { get; set; } = new List<ProjectTask>();
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
