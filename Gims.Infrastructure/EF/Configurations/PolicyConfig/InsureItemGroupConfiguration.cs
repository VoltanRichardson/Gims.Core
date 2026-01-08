using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Gims.Core.Domain.Policy;

public class InsureItemGroupConfiguration : IEntityTypeConfiguration<InsureItemGroup>
{
    public void Configure(EntityTypeBuilder<InsureItemGroup> builder)
    {
        builder.ToTable("InsureItemGroups");

        builder.HasKey(g => g.InsureItemGroupId);

        builder.Property(g => g.Name)
               .HasMaxLength(200)
               .IsRequired();

        builder.Property(g => g.Description)
               .HasMaxLength(500);
    }
}