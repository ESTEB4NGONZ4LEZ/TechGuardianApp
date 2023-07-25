
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class ArlConfiguration : IEntityTypeConfiguration<Arl>
{
    public void Configure(EntityTypeBuilder<Arl> builder)
    {
        builder.ToTable("arl");

        builder.Property(a => a.Id_arl)
        .IsRequired();

        builder.Property(a => a.Nombre)
        .HasMaxLength(50)
        .IsRequired();
    }
}
