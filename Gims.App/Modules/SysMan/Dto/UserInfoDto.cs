namespace Gims.App.Modules.SysMan.Dto;
public class UserInfoDto
{
    public Guid Id { get; set; }
    public List<string> Roles { get; set; } = new();
}