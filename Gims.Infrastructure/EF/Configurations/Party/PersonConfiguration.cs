using Gims.Core.Domain.Party;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("Persons");

        builder.OwnsOne(p => p.Address, a =>
        {
            a.Property(x => x.Line1).HasColumnName("AddressLine1");
            a.Property(x => x.Line2).HasColumnName("AddressLine2");
            a.Property(x => x.City).HasColumnName("City");
            a.Property(x => x.Country).HasColumnName("Country");
            a.Property(x => x.PostalCode).HasColumnName("PostalCode");
        });

        builder.OwnsOne(p => p.ContactInfo, ci =>
        {
            ci.Property(x => x.Email).HasColumnName("Email");
            ci.Property(x => x.Phone).HasColumnName("Phone");
        });
    }
}