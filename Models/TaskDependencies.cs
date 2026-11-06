namespace ProjectManagement.Api.Models;

public class TaskDependency
{
    public Guid Id { get; set; }

    public Guid PredecessorTaskId { get; set; }

    public Guid SuccessorTaskId { get; set; }

    public string? Type { get; set; }

    public int? LagMinutes { get; set; }

    // Navigation properties
    public TaskItem PredecessorTask { get; set; } = null!;

    public TaskItem SuccessorTask { get; set; } = null!;
}