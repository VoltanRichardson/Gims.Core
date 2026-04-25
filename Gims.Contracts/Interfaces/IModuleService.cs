using Gims.Contracts.Dto;

namespace Gims.Contracts.Interface;

public interface IModuleService
{
    Task<List<ModuleDto>> GetAvailableModulesAsync(List<string> roleCodes);
}