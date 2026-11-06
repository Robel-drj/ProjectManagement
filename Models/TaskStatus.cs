namespace ProjectManagement.Api.Models;

public class TaskStatus
{
    public Guid Id { get; set; }

    public Guid ProjectId { get; set; }

    public string? Name { get; set; }

    public string? Category { get; set; }

    public int? SortOrder { get; set; }

    // Navigation properties
    public Project Project { get; set; } = null!;
}