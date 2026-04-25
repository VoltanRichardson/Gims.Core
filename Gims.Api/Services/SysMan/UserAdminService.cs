using Gims.Contracts.Dto;

namespace Gims.Api.Services.SysMan;

public class UserAdminService : IUserAdminService
{
    public Task<List<UserDto>> GetUsersAsync()
    {
        var users = new List<UserDto>
    {
        new UserDto
        {
            Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
            Username = "admin",
            Email = "admin@example.com",
            Roles = new List<string> { "Admin" }
        }
    };

        return Task.FromResult(users);
    }

    public Task<UserDto?> GetUserAsync(Guid id)
    {
        var user = new UserDto
        {
            Id = id,
            Username = "bootstrap",
            Email = "bootstrap@example.com",
            Roles = new List<string> { "Admin" }
        };

        return Task.FromResult<UserDto?>(user);
    }
    public Task<UserDto> CreateUserAsync(UserDto dto) => throw new NotImplementedException();
    public Task<UserDto> UpdateUserAsync(UserDto dto) => throw new NotImplementedException();
    public Task DeleteUserAsync(Guid id) => throw new NotImplementedException();
    public Task<List<string>> GetUserRolesAsync(Guid id)
    {
        // Temporary bootstrap stub
        return Task.FromResult(new List<string> { "Admin" });
    }
}