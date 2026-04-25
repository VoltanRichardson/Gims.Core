using Gims.Contracts.Dto;

namespace Gims.Api.Services.SysMan;

public interface IRoleAdminService
{
    Task<List<RoleDto>> GetRolesAsync();
    Task<RoleDto?> GetRoleAsync(Guid id);
    Task DeleteRoleAsync(Guid id);

    Task<List<string>> GetRolePermissionsAsync(Guid roleId);
    Task AssignPermissionsAsync(AssignPermissionRequest request);
    Task RemovePermissionAsync(Guid roleId, Guid permissionId);
}