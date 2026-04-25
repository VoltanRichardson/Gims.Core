namespace Gims.UI.Registry;

public class UiModule
{
    public Guid Id { get; init; }
    public string Code { get; init; } = "";
    public string Name { get; init; } = "";
    public string Icon { get; init; } = "";
    public bool IsPermanent { get; init; }
    public int Order { get; init; }
    public string Category { get; set; } = "General";
    public string[] RequiredPermissions { get; set; } = Array.Empty<string>();
    public Type Component { get; init; } = typeof(object);
    public Dictionary<string, object>? ComponentParameters { get; init; }

    // --- Compatibility with old UI ---
    public string Title => Name;
    public object? RenderFragment => null; // old UI expects this but won't use it
}