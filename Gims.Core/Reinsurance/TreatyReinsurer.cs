namespace Gims.Core.Reinsurance
{
    public class TreatyReinsurer
    {
        public Guid TreatyId { get; private set; }
        public Treaty Treaty { get; private set; }

        public Guid ReinsurerId { get; private set; }
        public Reinsurer Reinsurer { get; private set; }

        public decimal? Share { get; private set; }
        public bool IsLead { get; private set; }

        private TreatyReinsurer() { } // EF Core

        public TreatyReinsurer(Guid treatyId, Guid reinsurerId, decimal? share, bool isLead)
        {
            TreatyId = treatyId;
            ReinsurerId = reinsurerId;
            Share = share;
            IsLead = isLead;
        }
    }
}