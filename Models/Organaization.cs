namespace ProjectManagement.Api.Models;

public class Organization
{
  public ICollection<Project> Projects { get; set; } = new List<Project>();
  public ICollection<SsoConnection> SsoConnections { get; set; } = new List<SsoConnection>();
public ICollection<ApiKey> ApiKeys { get; set; } = new List<ApiKey>();
public ICollection<AuditLog> AuditLogs { get; set; } = new List<AuditLog>();
  public ICollection<ResourcePermission> ResourcePermissions { get; set; } = new List<ResourcePermission>();
  public ICollection<Team> Teams { get; set; }
    = new List<Team>();
    public ICollection<Role> Roles { get; set; }
    = new List<Role>();
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Slug { get; set; }

    public string? Plan { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedAt { get; set; }
}