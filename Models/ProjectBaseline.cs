
using System.Collections.Generic;

namespace ProjectManagement.Api.Models;

public class ProjectBaseline
{
    public Guid Id { get; set; }
    public Guid ProjectId { get; set; }
    public string Name { get; set; } = null!;
    public Guid CreatedById { get; set; }
    public DateTimeOffset CapturedAt { get; set; }

    public Project Project { get; set; } = null!;
    public User CreatedBy { get; set; } = null!;
    public ICollection<BaselineItem> Items { get; set; } = new List<BaselineItem>();
}
