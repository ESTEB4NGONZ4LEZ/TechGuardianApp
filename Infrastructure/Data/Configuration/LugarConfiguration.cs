
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class LugarConfiguration : IEntityTypeConfiguration<Lugar>
{
    public void Configure(EntityTypeBuilder<Lugar> builder)
    {
        builder.ToTable("lugar");

        builder.Property(a => a.Id_lugar)
        .IsRequired();

        builder.Property(a => a.Nombre)
        .HasMaxLength(50)
        .IsRequired();

        builder.HasOne(a => a.Area)
        .WithMany(e => e.Lugares)
        .HasForeignKey(i => i.Id_area)
        .IsRequired();
    }
}