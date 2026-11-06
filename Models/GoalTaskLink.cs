namespace ProjectManagement.Api.Models;

public class GoalTaskLink
{
    public Guid Id { get; set; }
    public Guid GoalId { get; set; }
    public Guid TaskId { get; set; }
    public decimal Weight { get; set; }

    public ProjectGoal Goal { get; set; } = null!;
    public TaskItem Task { get; set; } = null!;
}
