using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Gims.Core.Domain.Reinsurance;

public class ReinsurerConfiguration : IEntityTypeConfiguration<Reinsurer>
{
    public void Configure(EntityTypeBuilder<Reinsurer> builder)
    {
        builder.ToTable("Reinsurers");

        builder.HasKey(r => r.ReinsurerId);

        // Party relationship
        builder.HasOne(r => r.Party)
               .WithMany() // assuming Party doesn’t track Reinsurers
               .HasForeignKey(r => r.PartyId)
               .IsRequired();

        // Name is optional in your domain (constructor doesn’t always set it)
        builder.Property(r => r.Name)
               .HasMaxLength(200);

        // Rating + LicenseNumber are optional
        builder.Property(r => r.Rating)
               .HasMaxLength(50);

        builder.Property(r => r.LicenseNumber)
               .HasMaxLength(100);
    }
}