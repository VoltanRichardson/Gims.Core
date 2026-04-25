using Gims.UI.ShellUI.Workspace;
using Microsoft.AspNetCore.Components;
using System.Net.NetworkInformation;

namespace Gims.UI.ShellUI;

public partial class PortalShell : ComponentBase
{
    protected override void OnInitialized()
    {
        //Workspace.OnChange += HandleWorkspaceChange;
        //Workspace.Initialize();
    }

    private void HandleWorkspaceChange()
    {
        InvokeAsync(StateHasChanged);
    }
}