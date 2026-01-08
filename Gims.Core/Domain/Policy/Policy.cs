namespace Gims.Core.Domain.Policy;

using Gims.Core.Domain.Party;

public class Policy
{
    public Guid PolicyId { get; private set; } = Guid.NewGuid();

    public PolicyNumber PolicyNumber { get; private set; }
    public PolicyStatus Status { get; private set; } = PolicyStatus.Draft;

    public PolicyPeriod Period { get; private set; }

    private readonly List<PolicyHolder> _policyHolders = new();
    public IReadOnlyList<PolicyHolder> PolicyHolders => _policyHolders;

    public Policy(PolicyNumber policyNumber, PolicyPeriod period)
    {
        PolicyNumber = policyNumber;
        Period = period;
    }

    public void AddPolicyHolder(Party party, DateTime effectiveDate)
    {
        _policyHolders.Add(new PolicyHolder(party, effectiveDate));
    }

    public void Activate()
    {
        Status = PolicyStatus.Active;
    }

    public void Cancel()
    {
        Status = PolicyStatus.Cancelled;
    }

    private Policy() { }

    private readonly List<InsureItemGroup> _insureItemGroups = new();
    public IReadOnlyList<InsureItemGroup> InsureItemGroups => _insureItemGroups;

    public InsureItemGroup CreateInsureItemGroup(string name, string? description = null)
    {
        var group = new InsureItemGroup(name, description);
        _insureItemGroups.Add(group);
        return group;
    }

    private readonly List<InsureItem> _insureItems = new();
    public IReadOnlyCollection<InsureItem> InsureItems => _insureItems;


    public void AddInsureItem(InsureItem item)
    {
        _insureItems.Add(item);
    }
}