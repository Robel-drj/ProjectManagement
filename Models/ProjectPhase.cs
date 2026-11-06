namespace ProjectManagement.Api.Models;

public class ProjectPhase
{
    public Guid Id { get; set; }

    public Guid ProjectId { get; set; }

    public string? Name { get; set; }

    public int? SortOrder { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    // Navigation properties
    public Project Project { get; set; } = null!;

    public ICollection<ProjectMilestone> ProjectMilestones { get; set; } = new List<ProjectMilestone>();
}