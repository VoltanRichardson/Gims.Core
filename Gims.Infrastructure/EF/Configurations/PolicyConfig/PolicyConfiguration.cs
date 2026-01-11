using Gims.Core.Domain.Policy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PolicyConfiguration : IEntityTypeConfiguration<Policy>
{
    public void Configure(EntityTypeBuilder<Policy> builder)
    {
        builder.ToTable("Policies");

        builder.HasKey(p => p.PolicyId);

        builder.Property(p => p.PolicyId)
               .ValueGeneratedNever();

        builder.OwnsOne(p => p.PolicyNumber, pn =>
        {
            pn.Property(x => x.Value)
              .HasColumnName("PolicyNumber")
              .HasMaxLength(50)
              .IsRequired();
        });

        builder.OwnsOne(p => p.PolicyPeriod, period =>
        {
            period.Property(x => x.StartDate)
                  .HasColumnName("EffectiveFrom")
                  .IsRequired();

            period.Property(x => x.EndDate)
                  .HasColumnName("EffectiveTo")
                  .IsRequired();
        });

        builder.HasMany(p => p.ItemGroups)
               .WithOne(g => g.Policy)
               .HasForeignKey(g => g.PolicyId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}