using Microsoft.AspNetCore.Components;

namespace Gims.UI.ShellUI.Workspace;

public partial class WorkspacePage : ComponentBase
{
    [Parameter] public string? ModuleCode { get; set; }

    protected override void OnParametersSet()
    {
        if (!string.IsNullOrWhiteSpace(ModuleCode))
            Workspace.Open(ModuleCode);
    }
}