using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CoverageTypeConfiguration : IEntityTypeConfiguration<CoverageType>
{
    public void Configure(EntityTypeBuilder<CoverageType> builder)
    {
        builder.ToTable("CoverageTypes");

        builder.HasKey(c => c.CoverageTypeId);

        builder.Property(c => c.Name)
               .HasMaxLength(100)
               .IsRequired();

        builder.Property(c => c.Description)
               .HasMaxLength(500);
    }
}