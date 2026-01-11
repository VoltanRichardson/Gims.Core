using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class RiskGroupItemLinkConfiguration : IEntityTypeConfiguration<RiskGroupItemLink>
{
    public void Configure(EntityTypeBuilder<RiskGroupItemLink> builder)
    {
        builder.ToTable("RiskGroupItemLinks");

        builder.HasKey(x => new { x.RiskGroupId, x.InsureItemId });

        builder.HasOne(x => x.RiskGroup)
               .WithMany(r => r.ItemLinks)
               .HasForeignKey(x => x.RiskGroupId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.InsureItem)
               .WithMany(i => i.RiskLinks)
               .HasForeignKey(x => x.InsureItemId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}