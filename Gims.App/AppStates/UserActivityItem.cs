
namespace Gims.App.AppState;

public class UserActivityItem
{
    public string Description { get; }
    public string Route { get; }
    public DateTime Timestamp { get; }

    public UserActivityItem(string description, string route)
    {
        Description = description;
        Route = route;
        Timestamp = DateTime.UtcNow;
    }
}