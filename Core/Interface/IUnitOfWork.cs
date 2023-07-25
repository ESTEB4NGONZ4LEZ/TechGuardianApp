
namespace Core.Interface;

public interface IUnitOfWork
{
    IArea Areas { get; }
    IArl Arl { get; }
    ICamper Camper { get; }
    ICamperPersona CamperPersona { get; }
    ICategoria Categoria { get; }
    IComponente Componente { get; }
    IEps Eps { get; }
    IEquipo Equipo { get; }
    IEquipoComponente EquipoComponente { get; }
    IEquipoLugar EquipoLugar { get; }
    IInsidente Insidente { get; }
    IJornada Jornada { get; }
    ILugar Lugar { get; }
    IPersona Persona { get; }
    ISalon Salon { get; }
    ITipoDocumento TipoDocumento { get; }
    ITipoInsidente TipoInsidente { get; }
    ITrainer Trainer { get; }
    ITrainerPersona TrainerPersona { get; }
    Task<int> SaveAsync();
}
