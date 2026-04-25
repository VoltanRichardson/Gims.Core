public class RiskGroup
{
    public Guid RiskGroupId { get; private set; }
    public string Name { get; private set; }
    public string? Description { get; private set; }

    private readonly List<RiskGroupItemLink> _itemLinks = new();
    public IReadOnlyCollection<RiskGroupItemLink> ItemLinks => _itemLinks;

    private RiskGroup() { }

    public RiskGroup(string name, string? description = null)
    {
        RiskGroupId = Guid.NewGuid();
        Name = name;
        Description = description;
    }
}