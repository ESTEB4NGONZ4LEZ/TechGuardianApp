
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class JornadaConfiguration : IEntityTypeConfiguration<Jornada>
{
    public void Configure(EntityTypeBuilder<Jornada> builder)
    {
        builder.ToTable("jornada");

        builder.Property(a => a.Id_jornada)
        .IsRequired();

        builder.Property(a => a.Nombre)
        .HasMaxLength(50)
        .IsRequired();
    }
}