
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class EquipoComponenteConfiguration : IEntityTypeConfiguration<EquipoComponente>
{
    public void Configure(EntityTypeBuilder<EquipoComponente> builder)
    {
        builder.ToTable("equipo_componente");

        builder.Property(a => a.Id_equipo_componente)
        .IsRequired();

        builder.HasOne(a => a.Equipo)
        .WithMany(e => e.EquipoComponentes)
        .HasForeignKey(i => i.Id_equipo)
        .IsRequired();

        builder.HasOne(a => a.Componente)
        .WithMany(e => e.EquipoComponentes)
        .HasForeignKey(i => i.id_componente)
        .IsRequired();
    }
}