namespace ProjectManagement.Api.Models;

public class RolePermission
{
    public Guid Id { get; set; }

    public Guid RoleId { get; set; }

    public Guid PermissionId { get; set; }

    // Navigation properties
    public Role Role { get; set; } = null!;

    public Permission Permission { get; set; } = null!;
}