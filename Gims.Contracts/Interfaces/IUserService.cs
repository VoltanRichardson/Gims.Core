using Gims.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gims.Contracts.Interface;

public interface IUserService
{
    Task<UserDto?> GetUserAsync(Guid userId);

}