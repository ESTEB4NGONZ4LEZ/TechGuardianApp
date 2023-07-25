
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class EquipoLugarConfiguration : IEntityTypeConfiguration<EquipoLugar>
{
    public void Configure(EntityTypeBuilder<EquipoLugar> builder)
    {
        builder.ToTable("equipo_lugar");

        builder.Property(a => a.Id_equipo_lugar)
        .IsRequired();

        builder.HasOne(a => a.Equipo)
        .WithMany(e => e.EquipoLugares)
        .HasForeignKey(i => i.Id_equipo)
        .IsRequired();

        builder.HasOne(a => a.Lugar)
        .WithMany(e => e.EquipoLugares)
        .HasForeignKey(i => i.Id_lugar)
        .IsRequired();
    }
}