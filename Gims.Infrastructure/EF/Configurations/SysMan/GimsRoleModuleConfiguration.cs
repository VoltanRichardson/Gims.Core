using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Gims.Core.SysMan.Entities;

public class GimsRoleModuleConfiguration : IEntityTypeConfiguration<GimsRoleModule>
{
    public void Configure(EntityTypeBuilder<GimsRoleModule> entity)
    {
        entity.ToTable("GimsRoleModules");

        entity.HasKey(rm => new { rm.RoleId, rm.ModuleId });

        entity.HasOne(rm => rm.Role)
            .WithMany()
            .HasForeignKey(rm => rm.RoleId);

        entity.HasOne(rm => rm.Module)
            .WithMany()
            .HasForeignKey(rm => rm.ModuleId);
    }
}