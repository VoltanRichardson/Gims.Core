namespace Gims.App.Modules.Navigation;

public class NavigationItem
{
    public string Title { get; set; } = "";
    public string Icon { get; set; } = "";
    public string Route { get; set; } = "";
    public List<NavigationItem> Children { get; set; } = new();
}