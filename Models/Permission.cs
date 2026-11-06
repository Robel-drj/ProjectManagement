namespace ProjectManagement.Api.Models;

public class Permission
{
    public Guid Id { get; set; }

    public string? Code { get; set; }

    public string? Description { get; set; }

    // Navigation property for the junction table
    public ICollection<RolePermission> RolePermissions { get; set; } 
        = new List<RolePermission>();
}