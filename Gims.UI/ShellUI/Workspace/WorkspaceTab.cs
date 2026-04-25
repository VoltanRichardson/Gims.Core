using Microsoft.AspNetCore.Components;
using Gims.UI.Registry;

namespace Gims.UI.ShellUI.Workspace;
public class WorkspaceTab
{
    public UiModule Module { get; }
    public Guid Id => Module.Id;

    // Cached render fragment
    public RenderFragment? RenderFragment { get; private set; }

    // Persistent component instance
    public IComponent? ComponentInstance { get; internal set; }

    // Has this tab rendered at least once?
    public bool HasRendered => RenderFragment != null;

    // Compatibility with old code
    public Dictionary<string, object>? ModuleParameters =>
        Module.ComponentParameters;

    public WorkspaceTab(UiModule module)
    {
        Module = module;
    }

    public void SetRender(RenderFragment fragment, IComponent instance)
    {
        RenderFragment = fragment;
        ComponentInstance = instance;
    }

    public void ClearRender()
    {
        RenderFragment = null;
        ComponentInstance = null;
    }
}