
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class TrainerPersonaConfiguration : IEntityTypeConfiguration<TrainerPersona>
{
    public void Configure(EntityTypeBuilder<TrainerPersona> builder)
    {
        builder.ToTable("trainer_persona");

        builder.Property(a => a.Id_trainer_persona)
        .IsRequired();

        builder.HasOne(a => a.Trainer)
        .WithMany(e => e.TrainerPersonas)
        .HasForeignKey(i => i.Id_trainer)
        .IsRequired();

        builder.HasOne(a => a.Persona)
        .WithMany(e => e.TrainerPersonas)
        .HasForeignKey(i => i.Id_persona)
        .IsRequired();
    }
}