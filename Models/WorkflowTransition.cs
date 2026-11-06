namespace ProjectManagement.Api.Models;

public class WorkflowTransition
{
    public Guid Id { get; set; }

    public Guid ProjectId { get; set; }

    public Guid FromStatusId { get; set; }

    public Guid ToStatusId { get; set; }

    public string? Conditions { get; set; } // jsonb

    // Navigation properties
    public Project Project { get; set; } = null!;

    public TaskStatus FromStatus { get; set; } = null!;

    public TaskStatus ToStatus { get; set; } = null!;
}