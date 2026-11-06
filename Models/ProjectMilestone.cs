namespace ProjectManagement.Api.Models;

public class ProjectMilestone
{
    public Guid Id { get; set; }

    public Guid ProjectId { get; set; }

    public Guid? PhaseId { get; set; }

    public string? Name { get; set; }

    public DateOnly? DueDate { get; set; }

    public string? Status { get; set; }

    // Navigation properties
    public Project Project { get; set; } = null!;

    public ProjectPhase? Phase { get; set; }

    public ICollection<ProjectDeliverable> ProjectDeliverables { get; set; } = new List<ProjectDeliverable>();
}