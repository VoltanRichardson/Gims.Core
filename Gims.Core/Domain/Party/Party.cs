
namespace Gims.Core.Domain.Party;

public abstract class Party
{
    public Guid PartyId { get; protected set; } = Guid.NewGuid();
    public PartyType PartyType { get; protected set; }

    public string DisplayName { get; protected set; } = string.Empty;

    public ContactInfo ContactInfo { get; protected set; }
    public Address? Address { get; protected set; }

    public List<Identifier> Identifiers { get; protected set; } = new();

    protected Party(PartyType type, string displayName, ContactInfo contactInfo)
    {
        PartyType = type;
        DisplayName = displayName;
        ContactInfo = contactInfo;
    }

    protected Party() { }
}