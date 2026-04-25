namespace Gims.Core.Policy;

using Gims.Core.Party;

public class Policy
{
    public Guid PolicyId { get; private set; }
    public PolicyNumber PolicyNumber { get; private set; }
    public PolicyPeriod PolicyPeriod { get; private set; }

    private readonly List<InsureItemGroup> _itemGroups = new();
    public IReadOnlyCollection<InsureItemGroup> ItemGroups => _itemGroups;

    private Policy() { }

    public Policy(PolicyNumber number, PolicyPeriod period)
    {
        PolicyId = Guid.NewGuid();
        PolicyNumber = number;
        PolicyPeriod = period;
    }
}