using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Gims.Core.Domain.Dms;

namespace Gims.Infrastructure.EF.Configurations.Dms
{
    public class DocumentVersionConfiguration : IEntityTypeConfiguration<DocumentVersion>
    {
        public void Configure(EntityTypeBuilder<DocumentVersion> builder)
        {
            builder.ToTable("DocumentVersions");

            builder.HasKey(v => v.DocumentVersionId);

            builder.Property(v => v.VersionNumber)
                   .IsRequired();

            builder.Property(v => v.StoragePath)
                   .HasMaxLength(500)
                   .IsRequired();

            builder.Property(v => v.FileSize)
                   .IsRequired();

            builder.Property(v => v.CreatedAt)
                   .IsRequired();
        }
    }
}