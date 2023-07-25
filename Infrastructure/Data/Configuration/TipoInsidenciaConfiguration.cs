
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class TipoInsidenciaConfiguration : IEntityTypeConfiguration<TipoInsidente>
{
    public void Configure(EntityTypeBuilder<TipoInsidente> builder)
    {
        builder.ToTable("tipo_insidencia");

        builder.Property(a => a.Id_tipo_insidente)
        .IsRequired();

        builder.Property(a => a.Nombre)
        .HasMaxLength(50)
        .IsRequired();
    }
}