public class InsureItemGroupLink
{
    public Guid InsureItemGroupId { get; private set; }
    public InsureItemGroup InsureItemGroup { get; private set; }

    public Guid InsureItemId { get; private set; }
    public InsureItem InsureItem { get; private set; }

    private InsureItemGroupLink() { }

    public InsureItemGroupLink(Guid groupId, Guid itemId)
    {
        InsureItemGroupId = groupId;
        InsureItemId = itemId;
    }
}