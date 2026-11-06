namespace ProjectManagement.Api.Models;

public class Board
{
    public Guid Id { get; set; }

    public Guid ProjectId { get; set; }

    public string? Name { get; set; }

    public string? BoardType { get; set; }

    // Navigation properties
    public Project Project { get; set; } = null!;

    public ICollection<BoardColumn> Columns { get; set; } = new List<BoardColumn>();
}