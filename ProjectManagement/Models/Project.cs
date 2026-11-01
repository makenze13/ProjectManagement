using System;
using System.Collections.Generic;

namespace ProjectManagement.Models;

public partial class Project
{
    public int IdProject { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateOnly? CreatedAt { get; set; }

    public virtual ICollection<ProjectTask> Tasks { get; set; } = new List<ProjectTask>();
}
