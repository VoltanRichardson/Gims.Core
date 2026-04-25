namespace Gims.Contracts.Dto
{
    public record RolePermissionsDto(
        Guid RoleId,
        List<PermissionDto> Permissions
    ); namespace Gims.Contracts.Dto
    {
        public record RolePermissionsDto(
            Guid RoleId,
            string RoleName,
            List<PermissionDto> Permissions
        );
    }
}