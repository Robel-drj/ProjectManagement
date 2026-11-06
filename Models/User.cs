namespace ProjectManagement.Api.Models;

public class User
{
    public ICollection<Project> ProjectsOwned { get; set; } = new List<Project>();
public ICollection<ProjectMember> ProjectMembers { get; set; } = new List<ProjectMember>();
    public ICollection<ApiKey> ApiKeysCreated { get; set; } = new List<ApiKey>();
public ICollection<AuditLog> AuditLogsPerformed { get; set; } = new List<AuditLog>();
    public ICollection<ResourcePermission> ResourcePermissions { get; set; } = new List<ResourcePermission>();
    public ICollection<TeamMember> TeamMembers { get; set; }
    = new List<TeamMember>();
    public Guid Id { get; set; }

    public string? Email { get; set; }

    public string? FullName { get; set; }

    public string? PasswordHash { get; set; }

    public string? AvatarUrl { get; set; }

    public string? Timezone { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedAt { get; set; }
}