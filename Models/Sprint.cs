
using System.Collections.Generic;

namespace ProjectManagement.Api.Models;

public class Sprint
{
    public Guid Id { get; set; }
    public Guid ProjectId { get; set; }
    public string Name { get; set; } = null!;
    public string Goal { get; set; } = null!;
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public string Status { get; set; } = null!;

    public Project Project { get; set; } = null!;
    public ICollection<SprintTask> SprintTasks { get; set; } = new List<SprintTask>();
    public ICollection<SprintReport> SprintReports { get; set; } = new List<SprintReport>();
    public ICollection<ProjectRetrospective> Retrospectives { get; set; } = new List<ProjectRetrospective>();
}
