using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Gims.Core.Domain.Dms;

namespace Gims.Infrastructure.EF.Configurations.Dms
{
    public class DocumentTypeConfiguration : IEntityTypeConfiguration<DocumentType>
    {
        public void Configure(EntityTypeBuilder<DocumentType> builder)
        {
            builder.ToTable("DocumentTypes");

            builder.HasKey(dt => dt.DocumentTypeId);

            builder.Property(dt => dt.Name)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(dt => dt.Description)
                   .HasMaxLength(500);
        }
    }
}