namespace Gims.App.Modules.SysMan.Dto
{
    public record ModuleRegistryEntryDto(
        Guid ModuleId,
        string Name,
        string Icon,
        string Url,
        bool IsActive
    );
}