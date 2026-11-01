using System;
using System.Collections.Generic;

namespace ProjectManagement.Models;

public partial class ProjectTask
{
    public int IdTask { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string Status { get; set; } = null!;

    public DateOnly CreatedAt { get; set; }

    public DateTime? DueDate { get; set; }

    public int? IdProject { get; set; }

    public int? IdEmployee { get; set; }

    public virtual Employee? IdemployeeNavigation { get; set; }

    public virtual Project? IdprojectNavigation { get; set; }
}
