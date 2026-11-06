namespace ProjectManagement.Api.Models;

public class ProjectDeliverable
{
    public Guid Id { get; set; }

    public Guid ProjectId { get; set; }

    public Guid? MilestoneId { get; set; }

    public string? Name { get; set; }

    public string? Status { get; set; }

    public DateOnly? DueDate { get; set; }

    // Navigation properties
    public Project Project { get; set; } = null!;

    public ProjectMilestone? Milestone { get; set; }
}