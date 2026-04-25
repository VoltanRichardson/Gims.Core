using System;
using System.Threading.Tasks;
using Gims.App.Modules.SysMan.Dto;

public interface IUserService
{
    Task<UserDto?> GetUserAsync(Guid userId);
}