namespace ProjectManagement.Api.Models;

public class BoardTask
{
    public Guid Id { get; set; }
    public Guid BoardId { get; set; }
    public Guid ColumnId { get; set; }
    public Guid TaskId { get; set; }
    public string Rank { get; set; } = null!;

    public Board Board { get; set; } = null!;
    public BoardColumn BoardColumn { get; set; } = null!;
    public TaskItem Task { get; set; } = null!;
}
