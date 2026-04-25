using System;
using System.Threading.Tasks;
using Gims.Contracts.Dto;
using Gims.Contracts.Interface;


namespace Gims.UI.Services;

public class UserService : IUserService
{
    private readonly UsersApiClient _api;

    public UserService(UsersApiClient api)
    {
        _api = api;
    }
        
    public Task<UserDto?> GetUserAsync(Guid userId)
        => _api.GetUserAsync(userId);   
}