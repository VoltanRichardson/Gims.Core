namespace Gims.Core.Domain.Policy;

public class InsureItemGroup
{
    public Guid InsureItemGroupId { get; private set; } = Guid.NewGuid();

    public string Name { get; private set; }
    public string? Description { get; private set; }

    private readonly List<InsureItem> _items = new();
    public IReadOnlyCollection<InsureItem> Items => _items;
    public InsureItemGroup(string name, string? description = null)
    {
        Name = name;
        Description = description;
    }

    public void AddItem(InsureItem item)
    {
        _items.Add(item);
    }

    private InsureItemGroup() { }
}