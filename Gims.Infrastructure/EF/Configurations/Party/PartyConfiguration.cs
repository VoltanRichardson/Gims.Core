using Gims.Core.Domain.Party;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gims.Infrastructure.EF.Configurations.Party
{
    public class PartyConfiguration : IEntityTypeConfiguration<Gims.Core.Domain.Party.Party>
    {
        public void Configure(EntityTypeBuilder<Gims.Core.Domain.Party.Party> builder)
        {
            builder.ToTable("Parties");

            builder.HasKey(p => p.PartyId);

            builder.Property(p => p.DisplayName)
                   .HasMaxLength(200)
                   .IsRequired();

            // Address (owned)
            builder.OwnsOne(p => p.Address, a =>
            {
                a.Property(x => x.Line1).HasColumnName("AddressLine1");
                a.Property(x => x.Line2).HasColumnName("AddressLine2");
                a.Property(x => x.City).HasColumnName("City");
                a.Property(x => x.Country).HasColumnName("Country");
                a.Property(x => x.PostalCode).HasColumnName("PostalCode");
            });

            // Identifiers (owned collection)
            builder.OwnsMany(p => p.Identifiers, id =>
            {
                id.ToTable("PartyIdentifiers");

                id.WithOwner().HasForeignKey("PartyId");

                id.Property(x => x.Type)
                    .HasColumnName("IdentifierType")
                    .HasMaxLength(100)
                    .IsRequired();

                id.Property(x => x.Value)
                    .HasColumnName("IdentifierValue")
                    .HasMaxLength(200)
                    .IsRequired();

                // FIX: Use CLR property name, not column name
                id.HasKey("PartyId", "Value");
            });

            // Contact info (owned)
            builder.OwnsOne(p => p.ContactInfo, ci =>
            {
                ci.Property(x => x.Email).HasColumnName("Email");
                ci.Property(x => x.Phone).HasColumnName("Phone");
            });

            // NOTE: Removed HasDiscriminator – let EF handle TPH by convention
        }
    }
}