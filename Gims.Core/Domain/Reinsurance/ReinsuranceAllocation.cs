namespace Gims.Core.Domain.Reinsurance;

using Gims.Core.Domain.Policy;

public class ReinsuranceAllocation
{
    public Guid AllocationId { get; private set; } = Guid.NewGuid();

    // The treaty this allocation belongs to
    public Guid TreatyId { get; private set; }
    public Treaty Treaty { get; private set; }

    // The policy (or item) being ceded
    public Guid PolicyId { get; private set; }
    public Policy Policy { get; private set; }

    // Optional: allocation at the item or group level
    public Guid? InsureItemGroupId { get; private set; }
    public Guid? InsureItemId { get; private set; }

    // Cession details
    public decimal CededPercentage { get; private set; } // e.g., 40% quota share
    public decimal? CededAmount { get; private set; }    // for XoL or facultative

    public DateTime EffectiveFrom { get; private set; }
    public DateTime EffectiveTo { get; private set; }

    private ReinsuranceAllocation() { } // EF Core

    public ReinsuranceAllocation(
        Treaty treaty,
        Policy policy,
        decimal cededPercentage,
        DateTime effectiveFrom,
        DateTime effectiveTo,
        decimal? cededAmount = null,
        Guid? insureItemGroupId = null,
        Guid? insureItemId = null)
    {
        Treaty = treaty ?? throw new ArgumentNullException(nameof(treaty));
        TreatyId = treaty.TreatyId;

        Policy = policy ?? throw new ArgumentNullException(nameof(policy));
        PolicyId = policy.PolicyId;

        CededPercentage = cededPercentage;
        CededAmount = cededAmount;

        EffectiveFrom = effectiveFrom;
        EffectiveTo = effectiveTo;

        InsureItemGroupId = insureItemGroupId;
        InsureItemId = insureItemId;
    }

    public bool AppliesTo(DateTime date)
        => date >= EffectiveFrom && date <= EffectiveTo;

    public void UpdateCededPercentage(decimal percentage)
        => CededPercentage = percentage;

    public void UpdateCededAmount(decimal? amount)
        => CededAmount = amount;
}