using Gims.Contracts.Dto;

namespace Gims.App.AppState;

public class OpenModule
{
    public ModuleDto Metadata { get; }

    public Guid ModuleId => Metadata.Id;
    public string Name => Metadata.Name;
    public int TabPriority => Metadata.TabPriority;

    public OpenModule(ModuleDto dto)
    {
        Metadata = dto;
    }
}