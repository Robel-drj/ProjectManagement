namespace ProjectManagement.Api.Models;

public class BaselineItem
{
    public Guid Id { get; set; }
    public Guid BaselineId { get; set; }
    public Guid TaskId { get; set; }
    public DateOnly PlannedStart { get; set; }
    public DateOnly PlannedEnd { get; set; }
    public decimal PlannedEffort { get; set; }

    public ProjectBaseline Baseline { get; set; } = null!;
    public TaskItem Task { get; set; } = null!;
}
