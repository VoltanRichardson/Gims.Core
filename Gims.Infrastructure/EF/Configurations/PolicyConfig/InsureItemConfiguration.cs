using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class InsureItemConfiguration : IEntityTypeConfiguration<InsureItem>
{
    public void Configure(EntityTypeBuilder<InsureItem> builder)
    {
        builder.ToTable("InsureItems");

        builder.HasKey(i => i.InsureItemId);

        builder.Property(i => i.Name)
               .HasMaxLength(200)
               .IsRequired();

        builder.Property(i => i.Description)
               .HasMaxLength(500);

        builder.Property(i => i.SumInsured);

        builder.Property(i => i.Usage)
               .HasMaxLength(100);

        // Navigation (no direct many-to-many here)
        builder.Navigation(i => i.GroupLinks).AutoInclude(false);
        builder.Navigation(i => i.RiskLinks).AutoInclude(false);
    }
}