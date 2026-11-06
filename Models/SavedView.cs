using System.Text.Json;
namespace ProjectManagement.Api.Models;

public class SavedView
{
    public Guid Id { get; set; }
    public Guid ProjectId { get; set; }
    public Guid OwnerId { get; set; }
    public string Name { get; set; } = null!;
    public string ViewType { get; set; } = null!;
    public JsonDocument? FilterJson { get; set; }
    public bool IsShared { get; set; }

    public Project Project { get; set; } = null!;
    public User Owner { get; set; } = null!;
}
