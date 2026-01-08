namespace Gims.Core.Domain.Policy;

using Gims.Core.Domain.Party;

public class PolicyHolder
{
    public Guid PolicyHolderId { get; private set; } = Guid.NewGuid();

    public Guid PartyId { get; private set; }
    public Party Party { get; private set; }

    public DateTime EffectiveDate { get; private set; }
    public DateTime? EndDate { get; private set; }

    public PolicyHolder(Party party, DateTime effectiveDate)
    {
        Party = party;
        PartyId = party.PartyId;
        EffectiveDate = effectiveDate;
    }

    public void Terminate(DateTime endDate)
    {
        EndDate = endDate;
    }

    private PolicyHolder() { }
}