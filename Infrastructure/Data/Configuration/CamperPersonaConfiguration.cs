
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class CamperPersonaConfiguration : IEntityTypeConfiguration<CamperPersona>
    {
        public void Configure(EntityTypeBuilder<CamperPersona> builder)
        {
            builder.ToTable("camper_persona");

            builder.Property(a => a.Id_camper_persona)
            .IsRequired();

            builder.HasOne(a => a.Camper)
            .WithMany(e => e.CamperPersonas)
            .HasForeignKey(i => i.Id_camper)
            .IsRequired();

            builder.HasOne(a => a.Persona)
            .WithMany(e => e.CamperPersonas)
            .HasForeignKey(i => i.Id_persona)
            .IsRequired();
        }
    }
}