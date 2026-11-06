namespace ProjectManagement.Api.Models;

public class CustomFieldValue
{
    public Guid Id { get; set; }

    public Guid TaskId { get; set; }

    public Guid FieldDefinitionId { get; set; }

    public string? Value { get; set; } // jsonb

    // Navigation properties
    public TaskItem Task { get; set; } = null!;

    public CustomFieldDefinition FieldDefinition { get; set; } = null!;
}