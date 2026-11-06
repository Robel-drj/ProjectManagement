namespace ProjectManagement.Api.Models;

public class CustomFieldDefinition
{
    public Guid Id { get; set; }

    public Guid ProjectId { get; set; }

    public string? Name { get; set; }

    public string? FieldType { get; set; }

    public string? Options { get; set; } // jsonb

    public bool IsRequired { get; set; }

    // Navigation properties
    public Project Project { get; set; } = null!;

    public ICollection<CustomFieldValue> CustomFieldValues { get; set; } = new List<CustomFieldValue>();
}