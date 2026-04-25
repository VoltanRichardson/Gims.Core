namespace Gims.App.Modules.SysMan.Dto
{
    public record CreateRoleRequest(
        string Code,
        string Name,
        string? Description
    );
}