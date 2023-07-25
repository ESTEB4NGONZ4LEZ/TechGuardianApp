
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class EpsConfiguration : IEntityTypeConfiguration<Eps>
{
    public void Configure(EntityTypeBuilder<Eps> builder)
    {
        builder.ToTable("eps");

        builder.Property(a => a.Id_arl)
        .IsRequired();

        builder.Property(a => a.Nombre)
        .HasMaxLength(50)
        .IsRequired();
    }
}
