using System.Collections.Generic;
using System.Threading.Tasks;
using Gims.Contracts.Interface;
using Gims.Contracts.Dto;

namespace Gims.UI.Services;

public class ModuleService : IModuleService
{
    private readonly ModulesApiClient _api;

    public ModuleService(ModulesApiClient api)
    {
        _api = api;
    }

    public Task<List<ModuleDto>> GetAvailableModulesAsync(List<string> roleCodes)
        => _api.GetAvailableModulesAsync(roleCodes);
}