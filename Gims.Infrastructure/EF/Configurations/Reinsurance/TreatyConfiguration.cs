using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Gims.Core.Domain.Reinsurance;

namespace Gims.Infrastructure.EF.Configurations.Reinsurance
{
    public class TreatyConfiguration : IEntityTypeConfiguration<Treaty>
    {
        public void Configure(EntityTypeBuilder<Treaty> builder)
        {
            builder.HasKey(t => t.TreatyId);

            builder.Property(t => t.TreatyNumber)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(t => t.Name)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(t => t.Type)
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

            // Relationship: Treaty ↔ TreatyReinsurers
            builder.HasMany(t => t.TreatyReinsurers)
                   .WithOne(tr => tr.Treaty)
                   .HasForeignKey(tr => tr.TreatyId);
        }
    }
}