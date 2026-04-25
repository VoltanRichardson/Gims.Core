using Gims.Contracts.Dto;

namespace Gims.Api.Services.SysMan;

public class RoleAdminService : IRoleAdminService
{
    public Task<List<RoleDto>> GetRolesAsync() => throw new NotImplementedException();
    public Task<RoleDto?> GetRoleAsync(Guid id) => throw new NotImplementedException();
    public Task DeleteRoleAsync(Guid id) => throw new NotImplementedException();

    public Task<List<string>> GetRolePermissionsAsync(Guid roleId) => throw new NotImplementedException();
    public Task AssignPermissionsAsync(AssignPermissionRequest request) => throw new NotImplementedException();
    public Task RemovePermissionAsync(Guid roleId, Guid permissionId) => throw new NotImplementedException();
}