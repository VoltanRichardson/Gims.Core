using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Gims.Core.Domain.Reinsurance;

public class TreatyConfiguration : IEntityTypeConfiguration<Treaty>
{
    public void Configure(EntityTypeBuilder<Treaty> builder)
    {
        builder.ToTable("Treaties");

        builder.HasKey(t => t.TreatyId);

        builder.Property(t => t.TreatyNumber)
               .HasMaxLength(50)
               .IsRequired();

        builder.Property(t => t.Name)
               .HasMaxLength(200)
               .IsRequired();

        builder.Property(t => t.Type)
               .HasConversion<string>() // TreatyType enum → string
               .HasMaxLength(50)
               .IsRequired();

        builder.Property(t => t.Capacity)
               .HasColumnType("decimal(18,2)");

        builder.Property(t => t.Retention)
               .HasColumnType("decimal(18,2)");

        builder.Property(t => t.Participation)
               .HasColumnType("decimal(5,2)");

        builder.Property(t => t.EffectiveFrom)
               .IsRequired();

        builder.Property(t => t.EffectiveTo)
               .IsRequired();

        // Many-to-many relationship: Treaty ↔ Reinsurers
        builder.HasMany(t => t.TreatyReinsurers)
               .WithMany();
        // If you want more control (e.g. allocation %, role), 
        // introduce a join entity like TreatyReinsurer.
    }
}