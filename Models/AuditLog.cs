namespace ProjectManagement.Api.Models;

public class AuditLog
{
    public Guid Id { get; set; }

    public Guid OrganizationId { get; set; }

    public Guid? ActorId { get; set; }

    public string? Action { get; set; }

    public string? TargetType { get; set; }

    public Guid? TargetId { get; set; }

    public string? Metadata { get; set; } // jsonb

    public DateTime? CreatedAt { get; set; }

    // Navigation properties
    public Organization Organization { get; set; } = null!;

    public User? Actor { get; set; }
}