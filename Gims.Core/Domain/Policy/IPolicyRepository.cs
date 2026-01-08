namespace Gims.Core.Domain.Policy;

public interface IPolicyRepository
{
    Task<Policy?> GetByIdAsync(Guid id);
    Task AddAsync(Policy policy);
    Task UpdateAsync(Policy policy);
}