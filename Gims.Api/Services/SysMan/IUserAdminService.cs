using Gims.Contracts.Dto;

namespace Gims.Api.Services.SysMan;

public interface IUserAdminService
{
    Task<List<UserDto>> GetUsersAsync();
    Task<UserDto?> GetUserAsync(Guid id);
    Task<UserDto> CreateUserAsync(UserDto dto);
    Task<UserDto> UpdateUserAsync(UserDto dto);
    Task DeleteUserAsync(Guid id);

    // Missing method required by UsersController
    Task<List<string>> GetUserRolesAsync(Guid id);
}