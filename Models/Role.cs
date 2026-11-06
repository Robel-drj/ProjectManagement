namespace ProjectManagement.Api.Models;

public class Role
{
    public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
    public ICollection<MemberRole> MemberRoles { get; set; } = new List<MemberRole>();
    public Guid Id { get; set; }

    public Guid OrganizationId { get; set; }

    public string? Name { get; set; }

    public string? Scope { get; set; }

    public bool? IsSystem { get; set; }

    // Navigation property
    public Organization Organization { get; set; } = null!;
}