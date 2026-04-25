namespace Gims.Core.Reinsurance
{
    using Gims.Core.Party;
    using System;
    using System.Collections.Generic;

    public class Reinsurer
    {
        public Guid ReinsurerId { get; private set; } = Guid.NewGuid();

        public Guid PartyId { get; private set; }
        public Party Party { get; private set; }

        public string Name { get; private set; }
        public string? Rating { get; private set; }
        public string? LicenseNumber { get; private set; }

        // Navigation to join entity
        public ICollection<TreatyReinsurer> TreatyReinsurers { get; private set; } = new List<TreatyReinsurer>();

        private Reinsurer() { } // EF Core

        public Reinsurer(Party party, string? rating = null, string? licenseNumber = null)
        {
            Party = party ?? throw new ArgumentNullException(nameof(party));
            PartyId = party.PartyId;
            Name = party.DisplayName;
            Rating = rating;
            LicenseNumber = licenseNumber;
        }

        public void UpdateRating(string rating) => Rating = rating;
        public void UpdateLicense(string license) => LicenseNumber = license;
    }
}