using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Gims.Core.Domain.Reinsurance;

namespace Gims.Infrastructure.EF.Configurations.Reinsurance
{
    public class TreatyReinsurerConfiguration : IEntityTypeConfiguration<TreatyReinsurer>
    {
        public void Configure(EntityTypeBuilder<TreatyReinsurer> builder)
        {
            builder.ToTable("TreatyReinsurers");

            // Composite key: Treaty + Reinsurer
            builder.HasKey(tr => new { tr.TreatyId, tr.ReinsurerId });

            builder.Property(tr => tr.Share)
                   .HasColumnType("decimal(5,2)");

            builder.Property(tr => tr.IsLead)
                   .IsRequired();

            // Relationships
            builder.HasOne(tr => tr.Treaty)
                   .WithMany(t => t.TreatyReinsurers)
                   .HasForeignKey(tr => tr.TreatyId);

            builder.HasOne(tr => tr.Reinsurer)
                   .WithMany(r => r.TreatyReinsurers)
                   .HasForeignKey(tr => tr.ReinsurerId);
        }
    }
}