using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Gims.Core.Domain.Workflow;

namespace Gims.Infrastructure.EF.Configurations.Workflow
{
    public class FunctionGroupConfiguration : IEntityTypeConfiguration<FunctionGroup>
    {
        public void Configure(EntityTypeBuilder<FunctionGroup> builder)
        {
            builder.ToTable("FunctionGroups");

            builder.HasKey(fg => fg.FunctionGroupId);

            builder.Property(fg => fg.Name)
                   .HasMaxLength(200)
                   .IsRequired();

            builder.Property(fg => fg.Description)
                   .HasMaxLength(500);

            builder.HasMany(fg => fg.Tasks)
                   .WithOne()
                   .HasForeignKey(t => t.FunctionGroupId);
        }
    }
}