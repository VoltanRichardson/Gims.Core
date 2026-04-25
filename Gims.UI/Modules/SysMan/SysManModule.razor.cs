using Microsoft.AspNetCore.Components;

namespace Gims.UI.Modules.SysMan;

public partial class SysManModule : ComponentBase
{
    public Type? CurrentPage { get; private set; }

    public void LoadPage(Type page)
    {
        CurrentPage = page;
        StateHasChanged();
    }
}