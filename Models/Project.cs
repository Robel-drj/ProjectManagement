namespace ProjectManagement.Api.Models;

public class Project
{
  public ICollection<WorkflowTransition> WorkflowTransitions { get; set; } = new List<WorkflowTransition>();
  public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
  public ICollection<TaskStatus> TaskStatuses { get; set; } = new List<TaskStatus>();
  public ICollection<TaskPriority> TaskPriorities { get; set; } = new List<TaskPriority>();
  public ICollection<ProjectPhase> ProjectPhases { get; set; } = new List<ProjectPhase>();
  public ICollection<ProjectMilestone> ProjectMilestones { get; set; } = new List<ProjectMilestone>();
  public ICollection<ProjectDeliverable> ProjectDeliverables { get; set; } = new List<ProjectDeliverable>();
  public ICollection<ProjectGoal> ProjectGoals { get; set; } = new List<ProjectGoal>();
  public ICollection<Label> Labels { get; set; } = new List<Label>();
    public Guid Id { get; set; }

    public Guid OrganizationId { get; set; }

    public string? Name { get; set; }

    public string? Key { get; set; }

    public string? Status { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? DueDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public Guid? OwnerId { get; set; }

    // Navigation properties
    public Organization Organization { get; set; } = null!;

    public User? Owner { get; set; }

    public ICollection<Board> Boards { get; set; } = new List<Board>();
    public ICollection<ProjectMember> ProjectMembers { get; set; } = new List<ProjectMember>();
    public ICollection<CustomFieldDefinition> CustomFieldDefinitions { get; set; } = new List<CustomFieldDefinition>();
}