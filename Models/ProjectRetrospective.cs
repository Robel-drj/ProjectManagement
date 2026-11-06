namespace ProjectManagement.Api.Models;

public class ProjectRetrospective
{
    public Guid Id { get; set; }
    public Guid ProjectId { get; set; }
    public Guid SprintId { get; set; }
    public string Title { get; set; } = null!;
    public string Notes { get; set; } = null!;
    public DateOnly HeldAt { get; set; }
    public Project Project { get; set; } = null!;
    public Sprint Sprint { get; set; } = null!;
}