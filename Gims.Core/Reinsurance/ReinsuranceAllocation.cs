namespace Gims.Core.Reinsurance
{
    public class ReinsuranceAllocation
    {
        public Guid AllocationId { get; set; }

        public Guid PolicyId { get; set; }

        public Guid TreatyId { get; set; }

        // Percentage or amount of the policy ceded to the treaty
        public decimal CededAmount { get; set; }

        // Navigation properties (optional but recommended)
        // public Treaty Treaty { get; set; }
        // public Policy Policy { get; set; }
    }
}