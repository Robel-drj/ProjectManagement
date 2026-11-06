namespace ProjectManagement.Api.Models;

public class ApiKey
{
    public Guid Id { get; set; }

    public Guid OrganizationId { get; set; }

    public string? Name { get; set; }

    public string? KeyHash { get; set; }

    public string? Scopes { get; set; } // jsonb

    public DateTime? ExpiresAt { get; set; }

    public DateTime? LastUsedAt { get; set; }

    public Guid? CreatedById { get; set; }

    // Navigation properties
    public Organization Organization { get; set; } = null!;

    public User? CreatedBy { get; set; }
}