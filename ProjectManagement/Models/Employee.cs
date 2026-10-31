using System;
using System.Collections.Generic;

namespace ProjectManagement.Models;

public partial class Employee
{
    public int Idemployee { get; set; }

    public string Fullname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateOnly? Createdat { get; set; }

    public virtual ICollection<ProjectTask> Tasks { get; set; } = new List<ProjectTask>();
}
