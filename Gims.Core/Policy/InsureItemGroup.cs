using Gims.Core.Policy;

public class InsureItemGroup
{
    public Guid InsureItemGroupId { get; private set; }
    public string Name { get; private set; }
    public string? Description { get; private set; }

    // Optional link to Policy
    public Guid? PolicyId { get; private set; }
    public Policy? Policy { get; private set; }

    private readonly List<InsureItemGroupLink> _itemLinks = new();
    public IReadOnlyCollection<InsureItemGroupLink> ItemLinks => _itemLinks;

    private InsureItemGroup() { }

    public InsureItemGroup(string name, string? description = null)
    {
        InsureItemGroupId = Guid.NewGuid();
        Name = name;
        Description = description;
    }
}