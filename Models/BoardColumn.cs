namespace ProjectManagement.Api.Models;

public class BoardColumn
{
    public Guid Id { get; set; }

    public Guid BoardId { get; set; }

    public Guid StatusId { get; set; }

    public string? Name { get; set; }

    public int? SortOrder { get; set; }

    public int? WipLimit { get; set; }

    // Navigation properties
    public Board Board { get; set; } = null!;

    public TaskStatus Status { get; set; } = null!;
}