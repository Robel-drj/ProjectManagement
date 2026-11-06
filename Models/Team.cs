namespace ProjectManagement.Api.Models;

public class Team
{
  public ICollection<ResourcePermission> ResourcePermissions { get; set; } = new List<ResourcePermission>();
  public ICollection<TeamMember> TeamMembers { get; set; }
    = new List<TeamMember>();
    public Guid Id { get; set; }

    public Guid OrganizationId { get; set; }

    public string? Name { get; set; }

    public string? Status { get; set; }

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    // Navigation property
    public Organization Organization { get; set; } = null!;
}