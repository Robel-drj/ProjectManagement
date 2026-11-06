namespace ProjectManagement.Api.Models;

public class TaskWatcher
{
    public Guid Id { get; set; }

    public Guid TaskId { get; set; }

    public Guid UserId { get; set; }

    // Navigation properties
    public TaskItem Task { get; set; } = null!;

    public User User { get; set; } = null!;
}