using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

        // Optional FK to Policy
        builder.HasOne(g => g.Policy)
               .WithMany(p => p.ItemGroups)
               .HasForeignKey(g => g.PolicyId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.Navigation(g => g.ItemLinks).AutoInclude(false);
    }
}