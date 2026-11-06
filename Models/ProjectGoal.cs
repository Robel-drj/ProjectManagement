namespace ProjectManagement.Api.Models;

public class ProjectGoal
{
    public Guid Id { get; set; }

    public Guid ProjectId { get; set; }

    public Guid? ParentId { get; set; }

    public string? Title { get; set; }

    public decimal? TargetValue { get; set; }

    public decimal? CurrentValue { get; set; }

    public DateOnly? DueDate { get; set; }

    public string? Status { get; set; }

    // Navigation properties
    public Project Project { get; set; } = null!;

    public ProjectGoal? Parent { get; set; }

    public ICollection<ProjectGoal> ChildGoals { get; set; } = new List<ProjectGoal>();
}