using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class InsureItemGroupLinkConfiguration : IEntityTypeConfiguration<InsureItemGroupLink>
{
    public void Configure(EntityTypeBuilder<InsureItemGroupLink> builder)
    {
        builder.ToTable("InsureItemGroupLinks");

        builder.HasKey(x => new { x.InsureItemGroupId, x.InsureItemId });

        builder.HasOne(x => x.InsureItemGroup)
               .WithMany(g => g.ItemLinks)
               .HasForeignKey(x => x.InsureItemGroupId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.InsureItem)
               .WithMany(i => i.GroupLinks)
               .HasForeignKey(x => x.InsureItemId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}