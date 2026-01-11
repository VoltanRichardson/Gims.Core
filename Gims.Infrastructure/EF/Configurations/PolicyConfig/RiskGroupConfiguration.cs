using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class RiskGroupConfiguration : IEntityTypeConfiguration<RiskGroup>
{
    public void Configure(EntityTypeBuilder<RiskGroup> builder)
    {
        builder.ToTable("RiskGroups");

        builder.HasKey(r => r.RiskGroupId);

        builder.Property(r => r.Name)
               .HasMaxLength(200)
               .IsRequired();

        builder.Property(r => r.Description)
               .HasMaxLength(500);

        builder.Navigation(r => r.ItemLinks).AutoInclude(false);
    }
}