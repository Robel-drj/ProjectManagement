namespace ProjectManagement.Api.Models;

public class SsoConnection
{
    public Guid Id { get; set; }

    public Guid OrganizationId { get; set; }

    public string? Protocol { get; set; }

    public string? Domain { get; set; }

    public string? Config { get; set; } // Represented as string/JSON for jsonb

    public bool? IsActive { get; set; }

    // Navigation property
    public Organization Organization { get; set; } = null!;
}