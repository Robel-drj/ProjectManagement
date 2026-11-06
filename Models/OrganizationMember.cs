namespace ProjectManagement.Api.Models;

public class OrganizationMember
{
    public ICollection<MemberRole> MemberRoles { get; set; } = new List<MemberRole>();

    public Guid Id { get; set; }

    public Guid OrganizationId { get; set; }

    public Guid UserId { get; set; }

    public string? Status { get; set; }

    public DateTime? JoinedAt { get; set; }

    // Navigation properties
    public Organization Organization { get; set; } = null!;

    public User User { get; set; } = null!;
}