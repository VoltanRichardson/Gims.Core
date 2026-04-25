using Gims.Contracts.Dto;
using Gims.Core.SysMan.Entities;

namespace Gims.App.AppState;

public class ModuleMetaData
{
    public Guid Id { get; }
    public string Name { get; }
    public bool IsComingSoon { get; }

    // UI metadata expected by NavigationBuilder
    public bool Active { get; set; } = false;
    public bool Visible { get; set; } = true;
    public bool IsImplemented { get; set; } = true;

    public string Code { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
    public string RoutePrefix { get; set; } = string.Empty;
    public string Route { get; set; } = string.Empty;

    // Must match AppState.Roles type
    public List<string> Roles { get; set; } = new();
    public List<ModuleMetaData> Submodules { get; set; } = new();

    public ModuleMetaData(ModuleDto dto)
    {
        Id = dto.Id;
        Name = dto.Name;
        IsComingSoon = dto.IsComingSoon;

        // dto does NOT contain these fields — so we do NOT map them
        // They remain configurable defaults
    }
}