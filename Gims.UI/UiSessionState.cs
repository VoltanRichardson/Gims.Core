namespace Gims.UI;

public class UiSessionState
{
    public HashSet<string> FavoriteModules { get; set; } = new();
    public List<string> RecentModules { get; set; } = new();
    public HashSet<string> UserPermissions { get; set; } = new();

    public bool UserHasPermissions(IEnumerable<string> required)
    {
        if (required is null || !required.Any())
            return true;

        return required.All(p => UserPermissions.Contains(p));
    }
}