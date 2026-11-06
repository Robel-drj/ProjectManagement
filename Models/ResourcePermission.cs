namespace ProjectManagement.Api.Models;

public class ResourcePermission
{
    public Guid Id { get; set; }

    public Guid OrganizationId { get; set; }

    public string? ResourceType { get; set; }

    public Guid? ResourceId { get; set; }

    public string? AccessLevel { get; set; }

    public Guid? UserId { get; set; }

    public Guid? TeamId { get; set; }

    // Navigation properties
    public Organization Organization { get; set; } = null!;

    public User? User { get; set; }

    public Team? Team { get; set; }
}