using Gims.Contracts.Dto;

namespace Gims.Api.Services.SysMan;

public interface IModuleAdminService
{
    Task<List<ModuleDto>> GetModulesAsync();
    Task<ModuleDto?> GetModuleAsync(Guid id);
    Task<ModuleDto> CreateModuleAsync(ModuleDto dto);
    Task<ModuleDto> UpdateModuleAsync(ModuleDto dto);
    Task DeleteModuleAsync(Guid id);
    Task<List<ModuleDto>> GetAvailableModulesAsync(List<string> roleCodes);
}