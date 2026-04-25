using Gims.Contracts.Dto;

namespace Gims.Api.Services.SysMan;

public class SubmoduleAdminService : ISubmoduleAdminService
{
    public Task<List<SubmoduleDto>> GetSubmodulesAsync() => throw new NotImplementedException();
    public Task<SubmoduleDto?> GetSubmoduleAsync(Guid id) => throw new NotImplementedException();
    public Task<SubmoduleDto> CreateSubmoduleAsync(SubmoduleDto dto) => throw new NotImplementedException();
    public Task<SubmoduleDto> UpdateSubmoduleAsync(SubmoduleDto dto) => throw new NotImplementedException();
    public Task DeleteSubmoduleAsync(Guid id) => throw new NotImplementedException();
}