namespace ProjectManagement.Api.Models;

public class MemberRole
{
    public Guid Id { get; set; }

    public Guid OrganizationMemberId { get; set; }

    public Guid RoleId { get; set; }

    public DateTime? AssignedAt { get; set; }

    // Navigation properties
    public OrganizationMember OrganizationMember { get; set; } = null!;

    public Role Role { get; set; } = null!;
}