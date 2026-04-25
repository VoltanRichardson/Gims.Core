using Gims.App.AppState;

namespace Gims.App.Modules.Navigation;

public class NavigationBuilder
{
    private readonly Gims.App.AppState.AppState _appState;

    public NavigationBuilder(Gims.App.AppState.AppState appState)
    {
        _appState = appState;
    }

    public IEnumerable<NavigationItem> Build()
    {
        var userRoles = _appState.Roles;

        return _appState.Modules
            .Where(m => m.Active)
            .Where(m => m.Visible)
            .Where(m => m.Roles.Any(r => userRoles.Contains(r)))
            .OrderBy(m => m.Name)
            .Select(m => new NavigationItem
            {
                Title = m.Name,
                Icon = m.Icon,
                Route = m.IsImplemented ? m.RoutePrefix : "/coming-soon",
                Children = BuildSubmodules(m.Code, userRoles)
            });
    }

    private List<NavigationItem> BuildSubmodules(string moduleCode, IReadOnlyList<string> userRoles)
    {
        return _appState.Modules
            .SelectMany(m => m.Submodules)
            .Where(s => s.Code == moduleCode)
            .Where(s => s.Active)
            .Where(s => s.Visible)
            .Where(s => s.Roles.Any(r => userRoles.Contains(r)))
            .OrderBy(s => s.Name)
            .Select(s => new NavigationItem
            {
                Title = s.Name,
                Icon = s.Icon,
                Route = s.IsImplemented ? s.Route : "/coming-soon"
            })
            .ToList();
    }
}