using Gims.Core.SysMan.Entities;
using Gims.Contracts.Dto;

namespace Gims.App.AppState;

public class AppState
{
    // --- User context ---
    public List<string> Roles { get; set; } = new();
    public UserDto? CurrentUser { get; set; }
    public UserContextService UserContext { get; set; }

    // --- Module metadata ---
    public List<ModuleMetaData> Modules { get; set; } = new();

    // --- UI state ---
    public List<string> RecentActivity { get; set; } = new();
    public List<string> Favorites { get; set; } = new();
    public string? LastVisitedModule { get; set; }

    public AppState(UserContextService userContext)
    {
        UserContext = userContext;
    }
}