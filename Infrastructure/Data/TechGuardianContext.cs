using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Data;

public class TechGuardianContext : DbContext
{
    public TechGuardianContext(DbContextOptions<TechGuardianContext> options) : base(options)
    {
    }
    // * ----- DbSet -----
    public DbSet<Area>? Areas { get; set; }
    public DbSet<Arl>? Arls { get; set; }
    public DbSet<Camper>? Campers { get; set; }
    public DbSet<CamperPersona>? CamperPersonas { get; set; }
    public DbSet<Categoria>? Categorias { get; set; }
    public DbSet<Componente>? Componentes { get; set; }
    public DbSet<Eps>? Epses { get; set; }
    public DbSet<Equipo>? Equipos { get; set; }
    public DbSet<EquipoComponente>? EquipoComponentes { get; set; }
    public DbSet<EquipoLugar>? EquipoLugares { get; set; }
    public DbSet<Insidente>? Insidentes { get; set; }
    public DbSet<Jornada>? Jornadas { get; set; }
    public DbSet<Lugar>? Lugares { get; set; }
    public DbSet<Persona>? Personas { get; set; }
    public DbSet<Salon>? Salones { get; set; }
    public DbSet<TipoDocumento>? TipoDocumentos { get; set; }
    public DbSet<TipoInsidente>? TipoInsidentes { get; set; }
    public DbSet<Trainer>? Trainers { get; set; }
    public DbSet<TrainerPersona>? TrainerPersonas { get; set; }
    // * ----- Carga Automatica de las Configuraciones ----- 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}