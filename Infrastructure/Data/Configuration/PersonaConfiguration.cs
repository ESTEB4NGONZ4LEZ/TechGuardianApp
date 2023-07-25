
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
{
    public void Configure(EntityTypeBuilder<Persona> builder)
    {
        builder.ToTable("persona");

        builder.Property(a => a.Id_persona)
        .IsRequired();

        builder.HasOne(a => a.TipoDocumento)
        .WithMany(e => e.Personas)
        .HasForeignKey(i => i.Id_tipo_documento)
        .IsRequired();

        builder.Property(a => a.Numero_documento)
        .HasMaxLength(50)
        .IsRequired();

        builder.Property(a => a.Nombre)
        .HasMaxLength(50)
        .IsRequired();

        builder.Property(a => a.Apellido)
        .HasMaxLength(50)
        .IsRequired();

        builder.Property(a => a.Email)
        .HasMaxLength(100)
        .IsRequired();

        builder.Property(a => a.Telefono)
        .HasMaxLength(30)
        .IsRequired();

        builder.HasOne(a => a.Salon)
        .WithMany(e => e.Personas)
        .HasForeignKey(i => i.Id_salon)
        .IsRequired();

        builder.HasOne(a => a.Jornada)
        .WithMany(e => e.Personas)
        .HasForeignKey(i => i.Id_jornada)
        .IsRequired();
    }
}