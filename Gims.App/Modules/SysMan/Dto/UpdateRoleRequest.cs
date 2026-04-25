namespace Gims.App.Modules.SysMan.Dto
{
    public record UpdateRoleRequest(
        Guid Id,
        string Code,
        string Name,
        string? Description
    );
}