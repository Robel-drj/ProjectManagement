namespace ProjectManagement.Api.Models;

public class TaskPriority
{
    public Guid Id { get; set; }

    public Guid ProjectId { get; set; }

    public string? Name { get; set; }

    public string? Color { get; set; }

    // Navigation properties
    public Project Project { get; set; } = null!;
}