namespace Gims.Contracts.Dto;

public class AssignPermissionRequest
{
    public Guid RoleId { get; set; }
    public List<Guid> PermissionIds { get; set; } = new();
}