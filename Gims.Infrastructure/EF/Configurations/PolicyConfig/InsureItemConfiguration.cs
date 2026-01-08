using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Gims.Core.Domain.Policy;

public class InsureItemConfiguration : IEntityTypeConfiguration<InsureItem>
{
    public void Configure(EntityTypeBuilder<InsureItem> builder)
    {
        builder.ToTable("InsureItems");

        builder.HasKey(i => i.InsureItemId);

        builder.Property(i => i.Description)
               .HasMaxLength(500)
               .IsRequired();

        // Add other properties as needed
        // builder.Property(i => i.SumInsured) — only if it exists
    }
}