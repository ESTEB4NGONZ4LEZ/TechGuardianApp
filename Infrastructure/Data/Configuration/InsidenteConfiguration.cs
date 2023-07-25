
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class InsidenteConfiguration : IEntityTypeConfiguration<Insidente>
{
    public void Configure(EntityTypeBuilder<Insidente> builder)
    {
        builder.ToTable("insidente");

        builder.Property(a => a.Id_insidente)
        .IsRequired();

        builder.HasOne(a => a.Persona)
        .WithMany(e => e.Insidentes)
        .HasForeignKey(i => i.Id_persona)
        .IsRequired();

        builder.HasOne(a => a.Categoria)
        .WithMany(e => e.Insidentes)
        .HasForeignKey(i => i.Id_categoria)
        .IsRequired();

        builder.HasOne(a => a.TipoInsidente)
        .WithMany(e => e.Insidentes)
        .HasForeignKey(i => i.Id_tipo_insidencia)
        .IsRequired();

        builder.HasOne(a => a.Area)
        .WithMany(e => e.Insidentes)
        .HasForeignKey(i => i.Id_area)
        .IsRequired();

        builder.Property(a => a.Descripcion)
        .IsRequired();

        builder.Property(a => a.Fecha)
        .HasColumnType("date")
        .IsRequired();
    }
}