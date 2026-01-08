namespace Gims.Core.Domain.Party;

public class Organization : Party
{
    public string LegalName { get; private set; } = string.Empty;
    public string? TradingName { get; private set; }

    public Organization(
        string legalName,
        string? tradingName,
        ContactInfo contactInfo)
        : base(PartyType.Organization, tradingName ?? legalName, contactInfo)
    {
        LegalName = legalName;
        TradingName = tradingName;
    }

    private Organization() { }
}