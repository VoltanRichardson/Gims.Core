using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Gims.Core.Domain.Dms;

public class DocumentConfiguration : IEntityTypeConfiguration<Document>
{
    public void Configure(EntityTypeBuilder<Document> builder)
    {
        builder.ToTable("Documents");

        builder.HasKey(d => d.DocumentId);

        builder.Property(d => d.Title)
               .HasMaxLength(200)
               .IsRequired();

        builder.Property(d => d.CreatedAt)
               .IsRequired();

        builder.HasOne(d => d.Type)
               .WithMany()
               .HasForeignKey(d => d.DocumentTypeId);

        builder.HasMany(d => d.Versions)
               .WithOne(v => v.Document)
               .HasForeignKey(v => v.DocumentId);
    }
}