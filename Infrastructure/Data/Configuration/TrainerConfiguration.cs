
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class TrainerConfiguration : IEntityTypeConfiguration<Trainer>
{
    public void Configure(EntityTypeBuilder<Trainer> builder)
    {
        builder.ToTable("trainer");

        builder.Property(a => a.Id_trainer)
        .IsRequired();

        builder.HasOne(a => a.Arl)
        .WithMany(e => e.Trainers)
        .HasForeignKey(i => i.Id_arl)
        .IsRequired();
    }
}