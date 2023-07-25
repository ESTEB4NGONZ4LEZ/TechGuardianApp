
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class ComponenteConfiguration : IEntityTypeConfiguration<Componente>
{
    public void Configure(EntityTypeBuilder<Componente> builder)
    {
        builder.ToTable("componente");
        
        builder.Property(a => a.id_componente)
        .IsRequired();

        builder.Property(a => a.Nombre)
        .HasMaxLength(50)
        .IsRequired();
    }
}
