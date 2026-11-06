using Microsoft.EntityFrameworkCore;
using ProjectManagement.Api.Models;
namespace ProjectManagement.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<WorkflowTransition> WorkflowTransitions { get; set; }
public DbSet<TaskItem> Tasks { get; set; }
        public DbSet<Models.TaskStatus> TaskStatuses { get; set; }
public DbSet<TaskPriority> TaskPriorities { get; set; }
        public DbSet<ProjectGoal> ProjectGoals { get; set; }
        public DbSet<ProjectPhase> ProjectPhases { get; set; }
public DbSet<ProjectMilestone> ProjectMilestones { get; set; }
public DbSet<ProjectDeliverable> ProjectDeliverables { get; set; }
        public DbSet<Permission> Permissions { get; set; }
public DbSet<RolePermission> RolePermissions { get; set; }
public DbSet<ResourcePermission> ResourcePermissions { get; set; }
        public DbSet<User> Users { get; set; }
    public DbSet<Organization> Organizations { get; set; }
    public DbSet<OrganizationMember> OrganizationMembers { get; set; }
    public DbSet<TeamMember> TeamMembers { get; set; }
    public DbSet<Role> Roles { get; set; }
public DbSet<SsoConnection> SsoConnections { get; set; }
public DbSet<ApiKey> ApiKeys { get; set; }
public DbSet<AuditLog> AuditLogs { get; set; }
public DbSet<MemberRole> MemberRoles { get; set; }
public DbSet<Project> Projects { get; set; }
public DbSet<ProjectMember> ProjectMembers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    // Configure workflow_transitions
modelBuilder.Entity<WorkflowTransition>(entity =>
{
    entity.ToTable("workflow_transitions");

    entity.HasKey(wt => wt.Id);

    entity.Property(wt => wt.Id)
        .HasColumnName("id");

    entity.Property(wt => wt.ProjectId)
        .HasColumnName("project_id");

    entity.Property(wt => wt.FromStatusId)
        .HasColumnName("from_status_id");

    entity.Property(wt => wt.ToStatusId)
        .HasColumnName("to_status_id");

    entity.Property(wt => wt.Conditions)
        .HasColumnName("conditions")
        .HasColumnType("jsonb");

    entity.HasOne(wt => wt.Project)
        .WithMany(p => p.WorkflowTransitions)
        .HasForeignKey(wt => wt.ProjectId);

    entity.HasOne(wt => wt.FromStatus)
        .WithMany()
        .HasForeignKey(wt => wt.FromStatusId)
        .OnDelete(DeleteBehavior.Restrict);

    entity.HasOne(wt => wt.ToStatus)
        .WithMany()
        .HasForeignKey(wt => wt.ToStatusId)
        .OnDelete(DeleteBehavior.Restrict);
});

// Configure tasks
modelBuilder.Entity<TaskItem>(entity =>
{
    entity.ToTable("tasks");

    entity.HasKey(t => t.Id);

    entity.Property(t => t.Id)
        .HasColumnName("id");

    entity.Property(t => t.ProjectId)
        .HasColumnName("project_id");

    entity.Property(t => t.PhaseId)
        .HasColumnName("phase_id");

    entity.Property(t => t.MilestoneId)
        .HasColumnName("milestone_id");

    entity.Property(t => t.ParentTaskId)
        .HasColumnName("parent_task_id");

    entity.Property(t => t.StatusId)
        .HasColumnName("status_id");

    entity.Property(t => t.PriorityId)
        .HasColumnName("priority_id");

    entity.Property(t => t.ReporterId)
        .HasColumnName("reporter_id");

    entity.Property(t => t.Title)
        .HasColumnName("title");

    entity.Property(t => t.Description)
        .HasColumnName("description");

    entity.Property(t => t.StartDate)
        .HasColumnName("start_date");

    entity.Property(t => t.DueDate)
        .HasColumnName("due_date");

    entity.Property(t => t.Estimate)
        .HasColumnName("estimate")
        .HasColumnType("numeric");

    entity.Property(t => t.SortKey)
        .HasColumnName("sort_key");

    entity.HasOne(t => t.Project)
        .WithMany(p => p.Tasks)
        .HasForeignKey(t => t.ProjectId);

    entity.HasOne(t => t.Phase)
        .WithMany()
        .HasForeignKey(t => t.PhaseId)
        .IsRequired(false);

    entity.HasOne(t => t.Milestone)
        .WithMany()
        .HasForeignKey(t => t.MilestoneId)
        .IsRequired(false);

    // Self-referencing relationship for sub-tasks
    entity.HasOne(t => t.ParentTask)
        .WithMany(t => t.SubTasks)
        .HasForeignKey(t => t.ParentTaskId)
        .IsRequired(false);

    entity.HasOne(t => t.Status)
        .WithMany()
        .HasForeignKey(t => t.StatusId)
        .OnDelete(DeleteBehavior.Restrict);

    entity.HasOne(t => t.Priority)
        .WithMany()
        .HasForeignKey(t => t.PriorityId)
        .OnDelete(DeleteBehavior.Restrict);

    entity.HasOne(t => t.Reporter)
        .WithMany(u => u.TasksReported)
        .HasForeignKey(t => t.ReporterId)
        .OnDelete(DeleteBehavior.Restrict);
});
    // Configure task_statuses
modelBuilder.Entity<Models.TaskStatus>(entity =>
{
    entity.ToTable("task_statuses");

    entity.HasKey(ts => ts.Id);

    entity.Property(ts => ts.Id)
        .HasColumnName("id");

    entity.Property(ts => ts.ProjectId)
        .HasColumnName("project_id");

    entity.Property(ts => ts.Name)
        .HasColumnName("name");

    entity.Property(ts => ts.Category)
        .HasColumnName("category");

    entity.Property(ts => ts.SortOrder)
        .HasColumnName("sort_order");

    entity.HasOne(ts => ts.Project)
        .WithMany(p => p.TaskStatuses)
        .HasForeignKey(ts => ts.ProjectId);
});

// Configure task_priorities
modelBuilder.Entity<TaskPriority>(entity =>
{
    entity.ToTable("task_priorities");

    entity.HasKey(tp => tp.Id);

    entity.Property(tp => tp.Id)
        .HasColumnName("id");

    entity.Property(tp => tp.ProjectId)
        .HasColumnName("project_id");

    entity.Property(tp => tp.Name)
        .HasColumnName("name");

    entity.Property(tp => tp.Color)
        .HasColumnName("color");

    entity.HasOne(tp => tp.Project)
        .WithMany(p => p.TaskPriorities)
        .HasForeignKey(tp => tp.ProjectId);
});
    // Configure project_goals
modelBuilder.Entity<ProjectGoal>(entity =>
{
    entity.ToTable("project_goals");

    entity.HasKey(pg => pg.Id);

    entity.Property(pg => pg.Id)
        .HasColumnName("id");

    entity.Property(pg => pg.ProjectId)
        .HasColumnName("project_id");

    entity.Property(pg => pg.ParentId)
        .HasColumnName("parent_id");

    entity.Property(pg => pg.Title)
        .HasColumnName("title");

    entity.Property(pg => pg.TargetValue)
        .HasColumnName("target_value")
        .HasColumnType("numeric");

    entity.Property(pg => pg.CurrentValue)
        .HasColumnName("current_value")
        .HasColumnType("numeric");

    entity.Property(pg => pg.DueDate)
        .HasColumnName("due_date");

    entity.Property(pg => pg.Status)
        .HasColumnName("status");

    entity.HasOne(pg => pg.Project)
        .WithMany(p => p.ProjectGoals)
        .HasForeignKey(pg => pg.ProjectId);

    // Self-referencing relationship for parent/child goals
    entity.HasOne(pg => pg.Parent)
        .WithMany(pg => pg.ChildGoals)
        .HasForeignKey(pg => pg.ParentId)
        .IsRequired(false);
});
    // Configure project_phases
modelBuilder.Entity<ProjectPhase>(entity =>
{
    entity.ToTable("project_phases");

    entity.HasKey(pp => pp.Id);

    entity.Property(pp => pp.Id)
        .HasColumnName("id");

    entity.Property(pp => pp.ProjectId)
        .HasColumnName("project_id");

    entity.Property(pp => pp.Name)
        .HasColumnName("name");

    entity.Property(pp => pp.SortOrder)
        .HasColumnName("sort_order");

    entity.Property(pp => pp.StartDate)
        .HasColumnName("start_date");

    entity.Property(pp => pp.EndDate)
        .HasColumnName("end_date");

    entity.HasOne(pp => pp.Project)
        .WithMany(p => p.ProjectPhases)
        .HasForeignKey(pp => pp.ProjectId);
});

// Configure project_milestones
modelBuilder.Entity<ProjectMilestone>(entity =>
{
    entity.ToTable("project_milestones");

    entity.HasKey(pm => pm.Id);

    entity.Property(pm => pm.Id)
        .HasColumnName("id");

    entity.Property(pm => pm.ProjectId)
        .HasColumnName("project_id");

    entity.Property(pm => pm.PhaseId)
        .HasColumnName("phase_id");

    entity.Property(pm => pm.Name)
        .HasColumnName("name");

    entity.Property(pm => pm.DueDate)
        .HasColumnName("due_date");

    entity.Property(pm => pm.Status)
        .HasColumnName("status");

    entity.HasOne(pm => pm.Project)
        .WithMany(p => p.ProjectMilestones)
        .HasForeignKey(pm => pm.ProjectId);

    entity.HasOne(pm => pm.Phase)
        .WithMany(pp => pp.ProjectMilestones)
        .HasForeignKey(pm => pm.PhaseId)
        .IsRequired(false);
});

// Configure project_deliverables
modelBuilder.Entity<ProjectDeliverable>(entity =>
{
    entity.ToTable("project_deliverables");

    entity.HasKey(pd => pd.Id);

    entity.Property(pd => pd.Id)
        .HasColumnName("id");

    entity.Property(pd => pd.ProjectId)
        .HasColumnName("project_id");

    entity.Property(pd => pd.MilestoneId)
        .HasColumnName("milestone_id");

    entity.Property(pd => pd.Name)
        .HasColumnName("name");

    entity.Property(pd => pd.Status)
        .HasColumnName("status");

    entity.Property(pd => pd.DueDate)
        .HasColumnName("due_date");

    entity.HasOne(pd => pd.Project)
        .WithMany(p => p.ProjectDeliverables)
        .HasForeignKey(pd => pd.ProjectId);

    entity.HasOne(pd => pd.Milestone)
        .WithMany(pm => pm.ProjectDeliverables)
        .HasForeignKey(pd => pd.MilestoneId)
        .IsRequired(false);
});
    // Configure projects
modelBuilder.Entity<Project>(entity =>
{
    entity.ToTable("projects");

    entity.HasKey(p => p.Id);

    entity.Property(p => p.Id)
        .HasColumnName("id");

    entity.Property(p => p.OrganizationId)
        .HasColumnName("organization_id");

    entity.Property(p => p.Name)
        .HasColumnName("name");

    entity.Property(p => p.Key)
        .HasColumnName("key");

    entity.Property(p => p.Status)
        .HasColumnName("status");

    entity.Property(p => p.StartDate)
        .HasColumnName("start_date");

    entity.Property(p => p.DueDate)
        .HasColumnName("due_date");

    entity.Property(p => p.EndDate)
        .HasColumnName("end_date");

    entity.Property(p => p.OwnerId)
        .HasColumnName("owner_id");

    entity.HasOne(p => p.Organization)
        .WithMany(o => o.Projects)
        .HasForeignKey(p => p.OrganizationId);

    entity.HasOne(p => p.Owner)
        .WithMany(u => u.ProjectsOwned)
        .HasForeignKey(p => p.OwnerId)
        .IsRequired(false);
});

// Configure project_members
modelBuilder.Entity<ProjectMember>(entity =>
{
    entity.ToTable("project_members");

    entity.HasKey(pm => pm.Id);

    entity.Property(pm => pm.Id)
        .HasColumnName("id");

    entity.Property(pm => pm.ProjectId)
        .HasColumnName("project_id");

    entity.Property(pm => pm.UserId)
        .HasColumnName("user_id");

    entity.Property(pm => pm.Role)
        .HasColumnName("role");

    entity.Property(pm => pm.JoinedAt)
        .HasColumnName("joined_at")
        .HasColumnType("timestamp with time zone");

    entity.HasOne(pm => pm.Project)
        .WithMany(p => p.ProjectMembers)
        .HasForeignKey(pm => pm.ProjectId);

    entity.HasOne(pm => pm.User)
        .WithMany(u => u.ProjectMembers)
        .HasForeignKey(pm => pm.UserId);
});
    // Configure sso_connections
modelBuilder.Entity<SsoConnection>(entity =>
{
    entity.ToTable("sso_connections");

    entity.HasKey(s => s.Id);

    entity.Property(s => s.Id)
        .HasColumnName("id");

    entity.Property(s => s.OrganizationId)
        .HasColumnName("organization_id");

    entity.Property(s => s.Protocol)
        .HasColumnName("protocol");

    entity.Property(s => s.Domain)
        .HasColumnName("domain");

    entity.Property(s => s.Config)
        .HasColumnName("config")
        .HasColumnType("jsonb");

    entity.Property(s => s.IsActive)
        .HasColumnName("is_active");

    entity.HasOne(s => s.Organization)
        .WithMany(o => o.SsoConnections)
        .HasForeignKey(s => s.OrganizationId);
});

// Configure api_keys
modelBuilder.Entity<ApiKey>(entity =>
{
    entity.ToTable("api_keys");

    entity.HasKey(ak => ak.Id);

    entity.Property(ak => ak.Id)
        .HasColumnName("id");

    entity.Property(ak => ak.OrganizationId)
        .HasColumnName("organization_id");

    entity.Property(ak => ak.Name)
        .HasColumnName("name");

    entity.Property(ak => ak.KeyHash)
        .HasColumnName("key_hash");

    entity.Property(ak => ak.Scopes)
        .HasColumnName("scopes")
        .HasColumnType("jsonb");

    entity.Property(ak => ak.ExpiresAt)
        .HasColumnName("expires_at")
        .HasColumnType("timestamp with time zone");

    entity.Property(ak => ak.LastUsedAt)
        .HasColumnName("last_used_at")
        .HasColumnType("timestamp with time zone");

    entity.Property(ak => ak.CreatedById)
        .HasColumnName("created_by_id");

    entity.HasOne(ak => ak.Organization)
        .WithMany(o => o.ApiKeys)
        .HasForeignKey(ak => ak.OrganizationId);

    entity.HasOne(ak => ak.CreatedBy)
        .WithMany(u => u.ApiKeysCreated)
        .HasForeignKey(ak => ak.CreatedById)
        .IsRequired(false);
});

// Configure audit_logs
modelBuilder.Entity<AuditLog>(entity =>
{
    entity.ToTable("audit_logs");

    entity.HasKey(al => al.Id);

    entity.Property(al => al.Id)
        .HasColumnName("id");

    entity.Property(al => al.OrganizationId)
        .HasColumnName("organization_id");

    entity.Property(al => al.ActorId)
        .HasColumnName("actor_id");

    entity.Property(al => al.Action)
        .HasColumnName("action");

    entity.Property(al => al.TargetType)
        .HasColumnName("target_type");

    entity.Property(al => al.TargetId)
        .HasColumnName("target_id");

    entity.Property(al => al.Metadata)
        .HasColumnName("metadata")
        .HasColumnType("jsonb");

    entity.Property(al => al.CreatedAt)
        .HasColumnName("created_at")
        .HasColumnType("timestamp with time zone");

    entity.HasOne(al => al.Organization)
        .WithMany(o => o.AuditLogs)
        .HasForeignKey(al => al.OrganizationId);

    entity.HasOne(al => al.Actor)
        .WithMany(u => u.AuditLogsPerformed)
        .HasForeignKey(al => al.ActorId)
        .IsRequired(false);
});
    modelBuilder.Entity<Permission>(entity =>
{
    entity.ToTable("permissions");

    entity.HasKey(p => p.Id);

    entity.Property(p => p.Id)
        .HasColumnName("id");

    entity.Property(p => p.Code)
        .HasColumnName("code");

    entity.Property(p => p.Description)
        .HasColumnName("description");
});

modelBuilder.Entity<RolePermission>(entity =>
    {
        entity.ToTable("role_permissions");

        entity.HasKey(rp => rp.Id);

        entity.Property(rp => rp.Id)
            .HasColumnName("id");

        entity.Property(rp => rp.RoleId)
            .HasColumnName("role_id");

        entity.Property(rp => rp.PermissionId)
            .HasColumnName("permission_id");

        entity.HasOne(rp => rp.Role)
            .WithMany(r => r.RolePermissions)
            .HasForeignKey(rp => rp.RoleId);

        entity.HasOne(rp => rp.Permission)
            .WithMany(p => p.RolePermissions)
            .HasForeignKey(rp => rp.PermissionId);
    });

modelBuilder.Entity<ResourcePermission>(entity =>
{
    entity.ToTable("resource_permissions");

    entity.HasKey(rp => rp.Id);

    entity.Property(rp => rp.Id)
        .HasColumnName("id");

    entity.Property(rp => rp.OrganizationId)
        .HasColumnName("organization_id");

    entity.Property(rp => rp.ResourceType)
        .HasColumnName("resource_type");

    entity.Property(rp => rp.ResourceId)
        .HasColumnName("resource_id");

    entity.Property(rp => rp.AccessLevel)
        .HasColumnName("access_level");

    entity.Property(rp => rp.UserId)
        .HasColumnName("user_id");

    entity.Property(rp => rp.TeamId)
        .HasColumnName("team_id");

    entity.HasOne(rp => rp.Organization)
        .WithMany(o => o.ResourcePermissions)
        .HasForeignKey(rp => rp.OrganizationId);

    entity.HasOne(rp => rp.User)
        .WithMany(u => u.ResourcePermissions)
        .HasForeignKey(rp => rp.UserId)
        .IsRequired(false);

    entity.HasOne(rp => rp.Team)
        .WithMany(t => t.ResourcePermissions)
        .HasForeignKey(rp => rp.TeamId)
        .IsRequired(false);
});
    modelBuilder.Entity<MemberRole>(entity =>
{
    entity.ToTable("member_roles");

    entity.HasKey(mr => mr.Id);

    entity.Property(mr => mr.Id)
        .HasColumnName("id");

    entity.Property(mr => mr.OrganizationMemberId)
        .HasColumnName("organization_member_id");

    entity.Property(mr => mr.RoleId)
        .HasColumnName("role_id");

    entity.Property(mr => mr.AssignedAt)
        .HasColumnName("assigned_at")
        .HasColumnType("timestamp with time zone");

    // Relationship with OrganizationMember
    entity.HasOne(mr => mr.OrganizationMember)
        .WithMany(om => om.MemberRoles)
        .HasForeignKey(mr => mr.OrganizationMemberId);

    // Relationship with Role
    entity.HasOne(mr => mr.Role)
        .WithMany(r => r.MemberRoles)
        .HasForeignKey(mr => mr.RoleId);
});
    modelBuilder.Entity<Role>(entity =>
{
    entity.ToTable("roles");

    entity.HasKey(r => r.Id);

    entity.Property(r => r.Id)
        .HasColumnName("id");

    entity.Property(r => r.OrganizationId)
        .HasColumnName("organization_id");

    entity.Property(r => r.Name)
        .HasColumnName("name");

    entity.Property(r => r.Scope)
        .HasColumnName("scope");

    entity.Property(r => r.IsSystem)
        .HasColumnName("is_system");

    // Relationship with Organization
    entity.HasOne(r => r.Organization)
        .WithMany(o => o.Roles)
        .HasForeignKey(r => r.OrganizationId);
});
    modelBuilder.Entity<TeamMember>(entity =>
{
    entity.ToTable("team_members");

    entity.HasKey(tm => tm.Id);

    entity.Property(tm => tm.Id)
        .HasColumnName("id");

    entity.Property(tm => tm.TeamId)
        .HasColumnName("team_id");

    entity.Property(tm => tm.UserId)
        .HasColumnName("user_id");

    entity.Property(tm => tm.Role)
        .HasColumnName("role");

    entity.Property(tm => tm.Status)
        .HasColumnName("status");

    entity.Property(tm => tm.JoinedAt)
        .HasColumnName("joined_at")
        .HasColumnType("timestamp with time zone");

    // Relationship with Team
    entity.HasOne(tm => tm.Team)
        .WithMany(t => t.TeamMembers)
        .HasForeignKey(tm => tm.TeamId);

    // Relationship with User
    entity.HasOne(tm => tm.User)
        .WithMany(u => u.TeamMembers)
        .HasForeignKey(tm => tm.UserId);
});
    modelBuilder.Entity<Team>(entity =>
{
    entity.ToTable("teams");

    entity.HasKey(t => t.Id);

    entity.Property(t => t.Id)
        .HasColumnName("id");

    entity.Property(t => t.OrganizationId)
        .HasColumnName("organization_id");

    entity.Property(t => t.Name)
        .HasColumnName("name");

    entity.Property(t => t.Status)
        .HasColumnName("status");

    entity.Property(t => t.Description)
        .HasColumnName("description");

    entity.Property(t => t.CreatedAt)
        .HasColumnName("created_at")
        .HasColumnType("timestamp with time zone");

    // One organization has many teams
    entity.HasOne(t => t.Organization)
        .WithMany(o => o.Teams)
        .HasForeignKey(t => t.OrganizationId);
});
    modelBuilder.Entity<OrganizationMember>(entity =>
    {
        entity.ToTable("organization_members");

        entity.HasKey(om => om.Id);

        entity.Property(om => om.Id)
            .HasColumnName("id");

        entity.Property(om => om.OrganizationId)
            .HasColumnName("organization_id");

        entity.Property(om => om.UserId)
            .HasColumnName("user_id");

        entity.Property(om => om.Status)
            .HasColumnName("status");

        entity.Property(om => om.JoinedAt)
            .HasColumnName("joined_at")
            .HasColumnType("timestamp with time zone");

        // Configure relationships
        entity.HasOne(om => om.Organization)
            .WithMany()
            .HasForeignKey(om => om.OrganizationId);

        entity.HasOne(om => om.User)
            .WithMany()
            .HasForeignKey(om => om.UserId);
    });
    modelBuilder.Entity<Organization>(entity =>
{
    entity.ToTable("organizations");

    entity.HasKey(o => o.Id);

    entity.Property(o => o.Id)
        .HasColumnName("id");

    entity.Property(o => o.Name)
        .HasColumnName("name");

    entity.Property(o => o.Slug)
        .HasColumnName("slug");

    entity.Property(o => o.Plan)
        .HasColumnName("plan");

    entity.Property(o => o.Status)
        .HasColumnName("status");

    entity.Property(o => o.CreatedAt)
        .HasColumnName("created_at")
        .HasColumnType("timestamp with time zone");
});
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<User>(entity =>
    {
        entity.ToTable("users");

        entity.HasKey(u => u.Id);

        entity.Property(u => u.Id)
            .HasColumnName("id");

        entity.Property(u => u.Email)
            .HasColumnName("email");

        entity.Property(u => u.FullName)
            .HasColumnName("full_name");

        entity.Property(u => u.PasswordHash)
            .HasColumnName("password");

        entity.Property(u => u.AvatarUrl)
            .HasColumnName("avatar_url");

        entity.Property(u => u.Timezone)
            .HasColumnName("timezone");

        entity.Property(u => u.Status)
            .HasColumnName("status");

        entity.Property(u => u.CreatedAt)
            .HasColumnName("created_at")
            .HasColumnType("timestamp with time zone");
    });
}
    }
    
}