namespace ProjectManagement.Api.Models;

public class TaskAssignee
{
    public Guid Id { get; set; }

    public Guid TaskId { get; set; }

    public Guid ProjectMemberId { get; set; }

    public DateTime? AssignedAt { get; set; }

    // Navigation properties
    public TaskItem Task { get; set; } = null!;

    public ProjectMember ProjectMember { get; set; } = null!;
}