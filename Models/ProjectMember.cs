namespace ProjectManagement.Api.Models;

public class ProjectMember
{
    public Guid Id { get; set; }

    public Guid ProjectId { get; set; }

    public Guid UserId { get; set; }

    public string? Role { get; set; }

    public DateTime? JoinedAt { get; set; }

    // Navigation properties
    public Project Project { get; set; } = null!;

    public User User { get; set; } = null!;

    public ICollection<TaskAssignee> AssignedTasks { get; set; } = new List<TaskAssignee>();
}