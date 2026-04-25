using Microsoft.AspNetCore.Components;

namespace Gims.UI.ShellUI.Workspace;

public partial class WorkspaceContent : ComponentBase
{
    [Inject] public WorkspaceController Workspace { get; set; }

    protected override void OnInitialized()
    {
        Workspace.OnChange += HandleWorkspaceChange;
    }

    private void HandleWorkspaceChange()
    {
        InvokeAsync(StateHasChanged);
    }
}