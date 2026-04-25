namespace Gims.UI.ShellUI.Workspace;

public class UserInterfaceState
{
    public List<string> RecentModules { get; set; } = new();
    public List<string> FavoriteModules { get; set; } = new();

    public string SearchText { get; set; } = string.Empty;

    public event Action? OnChange;

    public void NotifyChanged()
    {
        OnChange?.Invoke();
    }

    public bool UserHasPermissions(IEnumerable<string> permissions)
    {   // TEMP: allow everything
        return true;
    }
}