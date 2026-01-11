using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Gims.Core.Domain.Reinsurance;

namespace Gims.EF.Infrastructure.Configurations.Reinsurance
{
    public class ReinsurerConfiguration : IEntityTypeConfiguration<Reinsurer>
    {
        public void Configure(EntityTypeBuilder<Reinsurer> builder)
        {
            builder.ToTable("Reinsurers");

            builder.HasKey(r => r.ReinsurerId);

            builder.Property(r => r.Name)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(r => r.Rating)
                   .HasMaxLength(10);

            builder.Property(r => r.LicenseNumber)
                   .HasMaxLength(50);

            builder.HasOne(r => r.Party)
                   .WithMany()
                   .HasForeignKey(r => r.PartyId);

            builder.HasMany(r => r.TreatyReinsurers)
                   .WithOne(tr => tr.Reinsurer)
                   .HasForeignKey(tr => tr.ReinsurerId);
        }
    }
}