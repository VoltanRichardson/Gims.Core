using Gims.Contracts.Dto;

namespace Gims.Api.Services.SysMan;

public class ModuleAdminService : IModuleAdminService
{
    public Task<List<ModuleDto>> GetModulesAsync() => throw new NotImplementedException();
    public Task<ModuleDto?> GetModuleAsync(Guid id) => throw new NotImplementedException();
    public Task<ModuleDto> CreateModuleAsync(ModuleDto dto) => throw new NotImplementedException();
    public Task<ModuleDto> UpdateModuleAsync(ModuleDto dto) => throw new NotImplementedException();
    public Task DeleteModuleAsync(Guid id) => throw new NotImplementedException();
    public Task<List<ModuleDto>> GetAvailableModulesAsync(List<string> roleCodes)
    {
        var modules = new List<ModuleDto>
    {
        new ModuleDto
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
            Code = "dashboard",
            Name = "Dashboard",
            Description = "System dashboard",
            RoutePrefix = "/dashboard",
            DefaultRoute = "/dashboard",
            Icon = "dashboard",
            Category = "core",
            TabPriority = 0,
            Active = true,
            Visible = true,
            IsEnabled = true,
            IsImplemented = true,
            Roles = new List<string> { "Admin" },
            Submodules = new List<SubmoduleDto>()
        },

        new ModuleDto
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
            Code = "activity",
            Name = "Activity",
            Description = "Recent activity",
            RoutePrefix = "/activity",
            DefaultRoute = "/activity",
            Icon = "history",
            Category = "core",
            TabPriority = 1,
            Active = true,
            Visible = true,
            IsEnabled = true,
            IsImplemented = true,
            Roles = new List<string> { "Admin" },
            Submodules = new List<SubmoduleDto>()
        },

        new ModuleDto
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
            Code = "sysman",
            Name = "System Management",
            Description = "Administration module",
            RoutePrefix = "/sysman",
            DefaultRoute = "/sysman",
            Icon = "settings",
            Category = "admin",
            TabPriority = 99,
            Active = true,
            Visible = true,
            IsEnabled = true,
            IsImplemented = true,
            Roles = new List<string> { "Admin" },
            Submodules = new List<SubmoduleDto>()
        }
    };

        return Task.FromResult(modules);
    }
}