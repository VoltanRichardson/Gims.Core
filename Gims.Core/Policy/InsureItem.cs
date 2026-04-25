public class InsureItem
{
    public Guid InsureItemId { get; private set; }
    public string Name { get; private set; }
    public string? Description { get; private set; }

    // Optional metadata (varies by insurance type)
    public decimal? SumInsured { get; private set; }
    public string? Usage { get; private set; } // e.g., Private, Taxi, Trade

    // Many-to-many: InsureItem ↔ InsureItemGroup
    private readonly List<InsureItemGroupLink> _groupLinks = new();
    public IReadOnlyCollection<InsureItemGroupLink> GroupLinks => _groupLinks;

    // Many-to-many: InsureItem ↔ RiskGroup
    private readonly List<RiskGroupItemLink> _riskLinks = new();
    public IReadOnlyCollection<RiskGroupItemLink> RiskLinks => _riskLinks;

    private InsureItem() { }

    public InsureItem(string name, string? description = null)
    {
        InsureItemId = Guid.NewGuid();
        Name = name;
        Description = description;
    }
}