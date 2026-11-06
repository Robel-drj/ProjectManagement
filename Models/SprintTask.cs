namespace ProjectManagement.Api.Models;

public class SprintTask
{
    public Guid Id { get; set; }
    public Guid SprintId { get; set; }
    public Guid TaskId { get; set; }
    public DateTimeOffset AddedAt { get; set; }

    public Sprint Sprint { get; set; } = null!;
    public TaskItem Task { get; set; } = null!;
}
