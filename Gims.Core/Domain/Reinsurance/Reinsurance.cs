namespace Gims.Core.Domain.Reinsurance;

using Gims.Core.Domain.Party;

public class Reinsurer
{
    public Guid ReinsurerId { get; private set; } = Guid.NewGuid();

    // A Reinsurer is a Party in the role of providing reinsurance.
    public Guid PartyId { get; private set; }
    public string Name { get; private set; }
    public Party Party { get; private set; }

    public string? Rating { get; private set; }
    public string? LicenseNumber { get; private set; }

    private Reinsurer() { } // EF Core

    public Reinsurer(Party party, string? rating = null, string? licenseNumber = null)
    {
        Party = party ?? throw new ArgumentNullException(nameof(party));
        PartyId = party.PartyId;
        Rating = rating;
        LicenseNumber = licenseNumber;
    }

    public Reinsurer(Guid reinsurerId, string name)
    {
        ReinsurerId = reinsurerId;
        Name = name;
    }


    public void UpdateRating(string rating)
    {
        Rating = rating;
    }

    public void UpdateLicense(string license)
    {
        LicenseNumber = license;
    }
}