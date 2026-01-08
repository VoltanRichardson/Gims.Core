using Gims.Core.Domain.Policy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gims.Infrastructure.EF.Configurations;

public class PolicyConfiguration : IEntityTypeConfiguration<Policy>
{
    public void Configure(EntityTypeBuilder<Policy> builder)
    {
        builder.ToTable("Policies");

        builder.HasKey(p => p.PolicyId);

        builder.Property(p => p.PolicyId)
            .ValueGeneratedNever();

        // PolicyNumber is a value object
        builder.OwnsOne(p => p.PolicyNumber, pn =>
        {
            pn.Property(x => x.Value)
              .HasColumnName("PolicyNumber")
              .HasMaxLength(50)
              .IsRequired();
        });

        // Period is a value object
        builder.OwnsOne(p => p.Period, period =>
        {
            period.Property(x => x.StartDate)
                  .HasColumnName("EffectiveFrom")
                  .IsRequired();

            period.Property(x => x.EndDate)
                  .HasColumnName("EffectiveTo")
                  .IsRequired();
        });

        // PolicyHolders (child entity)
        builder.OwnsMany(p => p.PolicyHolders, ph =>
        {
            ph.ToTable("PolicyHolders");

            ph.WithOwner().HasForeignKey("PolicyId");

            ph.Property<Guid>("Id");
            ph.HasKey("Id");

            ph.Property(x => x.EffectiveDate)
              .IsRequired();

            ph.Property(x => x.PartyId)
              .IsRequired();
        });

        // InsureItemGroups
        builder.OwnsMany(p => p.InsureItemGroups, g =>
        {
            g.ToTable("InsureItemGroups");

            g.WithOwner().HasForeignKey("PolicyId");

            g.Property<Guid>("Id");
            g.HasKey("Id");

            g.Property(x => x.Name)
             .HasMaxLength(200)
             .IsRequired();

            g.Property(x => x.Description)
             .HasMaxLength(500);
        });

        // InsureItems
        builder.OwnsMany(p => p.InsureItems, i =>
        {
            i.ToTable("InsureItems");

            i.WithOwner().HasForeignKey("PolicyId");

            i.Property<Guid>("Id");
            i.HasKey("Id");

            i.Property(x => x.Description)
             .HasMaxLength(500)
             .IsRequired();


        });
    }
}