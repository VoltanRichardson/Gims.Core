using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Gims.Core.Domain.Dms;

namespace Gims.Infrastructure.EF.Configurations.Dms
{
    public class DocumentTagConfiguration : IEntityTypeConfiguration<DocumentTag>
    {
        public void Configure(EntityTypeBuilder<DocumentTag> builder)
        {
            builder.ToTable("DocumentTags");

            builder.HasKey(t => t.DocumentTagId);

            builder.Property(t => t.Name)
                   .HasMaxLength(100)
                   .IsRequired();

            // Many-to-many: Documents ↔ Tags
            builder.HasMany(t => t.Documents)
          .WithMany(d => d.Tags)
          .UsingEntity(j => j.ToTable("DocumentTagAssignments"));
        }
    }
}