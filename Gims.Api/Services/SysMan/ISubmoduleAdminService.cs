using Gims.Contracts.Dto;

namespace Gims.Api.Services.SysMan;

public interface ISubmoduleAdminService
{
    Task<List<SubmoduleDto>> GetSubmodulesAsync();
    Task<SubmoduleDto?> GetSubmoduleAsync(Guid id);
    Task<SubmoduleDto> CreateSubmoduleAsync(SubmoduleDto dto);
    Task<SubmoduleDto> UpdateSubmoduleAsync(SubmoduleDto dto);
    Task DeleteSubmoduleAsync(Guid id);
}