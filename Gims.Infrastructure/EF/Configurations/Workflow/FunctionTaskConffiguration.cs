using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Gims.Core.Domain.Workflow;

namespace Gims.Infrastructure.EF.Configurations.Workflow;
public class FunctionTaskConfiguration : IEntityTypeConfiguration<FunctionTask>
{
    public void Configure(EntityTypeBuilder<FunctionTask> builder)
    {
        builder.ToTable("FunctionTasks");

        builder.HasKey(ft => ft.FunctionTaskId);

        builder.Property(ft => ft.Name)
               .HasMaxLength(200)
               .IsRequired();

        builder.Property(ft => ft.Description)
               .HasMaxLength(500);

        builder.Property(ft => ft.Route)
               .HasMaxLength(200);

        builder.Property(ft => ft.PermissionKey)
               .HasMaxLength(100);

        // Relationship: FunctionTask → FunctionGroup
        builder.HasOne<FunctionGroup>()
               .WithMany(fg => fg.Tasks)
               .HasForeignKey(ft => ft.FunctionGroupId)
               .IsRequired();
    }
}