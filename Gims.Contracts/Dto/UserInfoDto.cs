namespace Gims.Contracts.Dto;
public class UserInfoDto
{
    public Guid Id { get; set; }
    public List<string> Roles { get; set; } = new();
}