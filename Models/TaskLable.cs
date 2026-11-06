namespace ProjectManagement.Api.Models;

public class TaskLabel
{
    public Guid Id { get; set; }

    public Guid TaskId { get; set; }

    public Guid LabelId { get; set; }

    // Navigation properties
    public TaskItem Task { get; set; } = null!;

    public Label Label { get; set; } = null!;
}