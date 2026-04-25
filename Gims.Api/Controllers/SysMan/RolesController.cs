using Microsoft.AspNetCore.Mvc;
using Gims.Api.Services.SysMan;
using Gims.Contracts.Dto;

namespace Gims.Api.Controllers.SysMan
{
    [ApiController]
    [Route("api/sysman/roles")]
    public class RolesController : ControllerBase
    {
        private readonly IRoleAdminService _roles;

        public RolesController(IRoleAdminService roles)
        {
            _roles = roles;
        }

        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            var result = await _roles.GetRolesAsync();
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetRole(Guid id)
        {
            var result = await _roles.GetRoleAsync(id);
            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteRole(Guid id)
        {
            await _roles.DeleteRoleAsync(id);
            return NoContent();
        }

        [HttpGet("{roleId:guid}/permissions")]
        public async Task<IActionResult> GetRolePermissions(Guid roleId)
        {
            var result = await _roles.GetRolePermissionsAsync(roleId);
            return Ok(result);
        }

        [HttpPost("{roleId:guid}/permissions")]
        public async Task<IActionResult> AssignPermissions(Guid roleId, [FromBody] AssignPermissionRequest request)
        {
            request.RoleId = roleId;
            await _roles.AssignPermissionsAsync(request);
            return Ok();
        }

        [HttpDelete("{roleId:guid}/permissions/{permissionId:guid}")]
        public async Task<IActionResult> RemovePermission(Guid roleId, Guid permissionId)
        {
            await _roles.RemovePermissionAsync(roleId, permissionId);
            return NoContent();
        }
    }
}