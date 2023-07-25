
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class TipoDocumentoConfiguration : IEntityTypeConfiguration<TipoDocumento>
{
    public void Configure(EntityTypeBuilder<TipoDocumento> builder)
    {
        builder.ToTable("tipo_documento");

        builder.Property(a => a.Id_tipo_documento)
        .IsRequired();

        builder.Property(a => a.Nombre)
        .HasMaxLength(50)
        .IsRequired();
    }
}