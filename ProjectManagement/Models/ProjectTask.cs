using System;
using System.Collections.Generic;

namespace ProjectManagement.Models;

public partial class ProjectTask
{
    public int Idtask { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string Status { get; set; } = null!;

    public DateOnly Createdat { get; set; }

    public DateTime? Duedate { get; set; }

    public int? Idproject { get; set; }

    public int? Idemployee { get; set; }

    public virtual Employee? IdemployeeNavigation { get; set; }

    public virtual Project? IdprojectNavigation { get; set; }
}
