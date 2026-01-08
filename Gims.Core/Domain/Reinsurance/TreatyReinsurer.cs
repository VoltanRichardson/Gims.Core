namespace Gims.Core.Domain.Reinsurance;

public class TreatyReinsurer
{
    public Guid TreatyId { get; private set; }
    public Treaty Treaty { get; private set; }

    public Guid ReinsurerId { get; private set; }
    public Reinsurer Reinsurer { get; private set; }

    public decimal? Share { get; private set; }   // % ceded to this reinsurer
    public bool IsLead { get; private set; }      // lead reinsurer flag

    private TreatyReinsurer() { } // EF Core

    public TreatyReinsurer(Guid treatyId, Guid reinsurerId, decimal? share = null, bool isLead = false)
    {
        TreatyId = treatyId;
        ReinsurerId = reinsurerId;
        Share = share;
        IsLead = isLead;
    }

    public void UpdateShare(decimal? share) => Share = share;
    public void SetLead(bool isLead) => IsLead = isLead;
}