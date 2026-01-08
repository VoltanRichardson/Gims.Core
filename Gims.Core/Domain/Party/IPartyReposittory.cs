namespace Gims.Core.Domain.Party;

public interface IPartyRepository
{
    Task<Party?> GetByIdAsync(Guid id);
    Task AddAsync(Party party);
    Task UpdateAsync(Party party);
}