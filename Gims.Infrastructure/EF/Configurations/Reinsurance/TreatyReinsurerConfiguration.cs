using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Gims.Core.Domain.Reinsurance;

public class TreatyReinsurerConfiguration : IEntityTypeConfiguration<TreatyReinsurer>
{
    public void Configure(EntityTypeBuilder<TreatyReinsurer> builder)
    {
        builder.ToTable("TreatyReinsurers");

        // Composite key: TreatyId + ReinsurerId
        builder.HasKey(tr => new { tr.TreatyId, tr.ReinsurerId });

        // Share percentage (optional)
        builder.Property(tr => tr.Share)
               .HasColumnType("decimal(5,2)");

        // Lead reinsurer flag
        builder.Property(tr => tr.IsLead)
               .IsRequired();

        // Relationships
        builder.HasOne(tr => tr.Treaty)
               .WithMany(t => t.TreatyReinsurers)
               .HasForeignKey(tr => tr.TreatyId);

        builder.HasOne(tr => tr.Reinsurer)
               .WithMany()
               .HasForeignKey(tr => tr.ReinsurerId);
    }
}