public class RiskGroupItemLink
{
    public Guid RiskGroupId { get; private set; }
    public RiskGroup RiskGroup { get; private set; }

    public Guid InsureItemId { get; private set; }
    public InsureItem InsureItem { get; private set; }

    private RiskGroupItemLink() { }

    public RiskGroupItemLink(Guid riskGroupId, Guid itemId)
    {
        RiskGroupId = riskGroupId;
        InsureItemId = itemId;
    }
}