public class GimsSystemSetting
{
    public Guid Id { get; set; }

    public string Key { get; set; } = default!;          // "Theme", "CompanyName"
    public string Value { get; set; } = default!;        // stored as string
    public string? Description { get; set; }
    public string? Category { get; set; }                // "UI", "Security", etc.

    public DateTime UpdatedAt { get; set; } 
}