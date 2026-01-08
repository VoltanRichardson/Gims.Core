using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Gims.Core.Domain.Reinsurance;

namespace Gims.Infrastructure.EF.Configurations.Reinsurance
{
    public class ReinsuranceAllocationConfiguration : IEntityTypeConfiguration<ReinsuranceAllocation>
    {
        public void Configure(EntityTypeBuilder<ReinsuranceAllocation> builder)
        {
            builder.ToTable("ReinsuranceAllocations");

            builder.HasKey(a => a.AllocationId);

            builder.Property(a => a.PolicyId)
                   .IsRequired();

            builder.Property(a => a.TreatyId)
                   .IsRequired();

            builder.Property(a => a.CededAmount)
                   .HasColumnType("decimal(5,2)") // e.g. 50.00% max
                   .IsRequired();

            // Relationships
            builder.HasOne<Treaty>()
                   .WithMany()
                   .HasForeignKey(a => a.TreatyId);

            // Policy relationship can be added once Policy aggregate is fully mapped
            // builder.HasOne<Policy>()
            //        .WithMany()
            //        .HasForeignKey(a => a.PolicyId);
        }
    }
}