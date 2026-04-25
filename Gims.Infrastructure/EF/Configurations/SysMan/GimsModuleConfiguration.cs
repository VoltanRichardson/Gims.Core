using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Gims.Core.SysMan.Entities;

public class GimsModuleConfiguration : IEntityTypeConfiguration<GimsModule>
{
    public void Configure(EntityTypeBuilder<GimsModule> entity)
    {
        entity.ToTable("GimsModules");

        entity.HasKey(m => m.Id);

        entity.Property(m => m.Code).IsRequired().HasMaxLength(100);
        entity.Property(m => m.Name).IsRequired().HasMaxLength(200);

        var jsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = false
        };

        entity.Property(m => m.Submodules)
            .HasConversion(
                v => JsonSerializer.Serialize(v, jsonOptions),
                v => JsonSerializer.Deserialize<List<GimsSubmodule>>(v, jsonOptions) ?? new List<GimsSubmodule>()
            );

        entity.Property(m => m.Roles)
            .HasConversion(
                v => JsonSerializer.Serialize(v, jsonOptions),
                v => JsonSerializer.Deserialize<List<string>>(v, jsonOptions) ?? new List<string>()
            );
    }
}