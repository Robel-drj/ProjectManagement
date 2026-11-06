namespace ProjectManagement.Api.Models;

public class SprintReport
{
    public Guid Id { get; set; }
    public Guid SprintId { get; set; }
    public decimal CommittedPoints { get; set; }
    public decimal CompletedPoints { get; set; }
    public decimal Velocity { get; set; }
    public DateTimeOffset GeneratedAt { get; set; }

    public Sprint Sprint { get; set; } = null!;
}
