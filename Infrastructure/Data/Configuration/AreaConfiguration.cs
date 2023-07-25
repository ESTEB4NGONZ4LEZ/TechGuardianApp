

using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class AreaConfiguration : IEntityTypeConfiguration<Area>
{
    public void Configure(EntityTypeBuilder<Area> builder)
    {
        builder.ToTable("area");

        builder.Property(a => a.Id_area)
        .IsRequired();

        builder.Property(a => a.Nombre)
        .HasMaxLength(50)
        .IsRequired();
    }
}
