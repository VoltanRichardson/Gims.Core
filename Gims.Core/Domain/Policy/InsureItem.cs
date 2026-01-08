namespace Gims.Core.Domain.Policy;

public abstract class InsureItem
{
    public Guid InsureItemId { get; private set; } = Guid.NewGuid();

    public string Description { get; protected set; } = string.Empty;

    protected InsureItem(string description)
    {
        Description = description;
    }

    protected InsureItem() { }
}