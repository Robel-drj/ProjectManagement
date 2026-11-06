namespace ProjectManagement.Api.Models;

public class TaskItem
{
    public Guid Id { get; set; }

    public Guid ProjectId { get; set; }

    public Guid? PhaseId { get; set; }

    public Guid? MilestoneId { get; set; }

    public Guid? ParentTaskId { get; set; }

    public Guid StatusId { get; set; }

    public Guid PriorityId { get; set; }

    public Guid ReporterId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? DueDate { get; set; }

    public decimal? Estimate { get; set; }

    public string? SortKey { get; set; }

    // Navigation properties
    public Project Project { get; set; } = null!;

    public ProjectPhase? Phase { get; set; }

    public ProjectMilestone? Milestone { get; set; }

    public TaskItem? ParentTask { get; set; }

    public ICollection<TaskItem> SubTasks { get; set; } = new List<TaskItem>();

    public TaskStatus Status { get; set; } = null!;

    public TaskPriority Priority { get; set; } = null!;

    public User Reporter { get; set; } = null!;

    public ICollection<TaskLabel> TaskLabels { get; set; } = new List<TaskLabel>();    
    public ICollection<TaskDependency> DependenciesWhereThisIsPredecessor { get; set; } = new List<TaskDependency>();
    public ICollection<TaskAssignee> TaskAssignees { get; set; } = new List<TaskAssignee>();
    public ICollection<TaskWatcher> TaskWatchers { get; set; } = new List<TaskWatcher>();
    public ICollection<CustomFieldValue> CustomFieldValues { get; set; } = new List<CustomFieldValue>();
    public ICollection<TaskDependency> DependenciesWhereThisIsSuccessor { get; set; } = new List<TaskDependency>();
}