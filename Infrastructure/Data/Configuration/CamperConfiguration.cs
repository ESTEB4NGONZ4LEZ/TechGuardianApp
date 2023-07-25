
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class CamperConfiguration : IEntityTypeConfiguration<Camper>
{
    public void Configure(EntityTypeBuilder<Camper> builder)
    {
        builder.ToTable("camper");

        builder.Property(a => a.Id_camper)
        .IsRequired();

        builder.HasOne(a => a.Eps)
        .WithMany(e => e.Campers)
        .HasForeignKey(i => i.Id_eps)
        .IsRequired();
    }
}
