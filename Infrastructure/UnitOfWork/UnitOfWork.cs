
using Core.Interface;
using Infrastructure.Data;
using Infrastructure.Repository;

namespace Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly TechGuardianContext context;
    private AreaRepository _areas;
    private ArlRepository _arl;
    private CamperPersonaRepository _camperPersona;
    private CamperRepository _camper;
    private CategoriaRepository _categoria;
    private ComponenteRepository _componente;
    private EpsRepository _eps;
    private EquipoComponenteRepository _equipoComponente;
    private EquipoLugarRepository _equipoLugar;
    private EquipoRepository _equipo;
    private InsidenteRepository _insidente;
    private JornadaRepository _jornada;
    private LugarRepository _lugar;
    private PersonaRepository _persona;
    private SalonRepository _salon;
    private TipoDocumentoRepository _tipoDocumento;
    private TipoInsidenteRepository _tipoInsidente;
    private TrainerPersonaRepository _trainerPersona;
    private TrainerRepository _trainer;
    // * ----- Constructor -----
    public UnitOfWork(TechGuardianContext _context)
    {
        context = _context;
    }

    public IArea Areas
    {
        get{
            if(_areas == null){
                _areas = new AreaRepository(context);
            }
            return _areas;
        }
    }
    public IArl Arl
    {
        get{
            if(_arl == null){
                _arl = new ArlRepository(context);
            }
            return _arl;
        }
    }
    public ICamperPersona CamperPersona
    {
        get{
            if(_camperPersona == null){
                _camperPersona = new CamperPersonaRepository(context);
            }
            return _camperPersona;
        }
    }
    public ICamper Camper
    {
        get{
            if(_camper == null){
                _camper = new CamperRepository(context);
            }
            return _camper;
        }
    }
    public ICategoria Categoria
    {
        get{
            if(_categoria == null){
                _categoria = new CategoriaRepository(context);
            }
            return _categoria;
        }
    }
    public IComponente Componente
    {
        get{
            if(_componente == null){
                _componente = new ComponenteRepository(context);
            }
            return _componente;
        }
    }
    public IEps Eps
    {
        get{
            if(_eps == null){
                _eps = new EpsRepository(context);
            }
            return _eps;
        }
    }
    public IEquipoComponente EquipoComponente
    {
        get{
            if(_equipoComponente == null){
                _equipoComponente = new EquipoComponenteRepository(context);
            }
            return _equipoComponente;
        }
    }
    public IEquipoLugar EquipoLugar
    {
        get{
            if(_equipoLugar == null){
                _equipoLugar = new EquipoLugarRepository(context);
            }
            return _equipoLugar;
        }
    }
    public IEquipo Equipo
    {
        get{
            if(_equipo == null){
                _equipo = new EquipoRepository(context);
            }
            return _equipo;
        }
    }
    public IInsidente Insidente
    {
        get{
            if(_insidente == null){
                _insidente = new InsidenteRepository(context);
            }
            return _insidente;
        }
    }
    public IJornada Jornada
    {
        get{
            if(_jornada == null){
                _jornada = new JornadaRepository(context);
            }
            return _jornada;
        }
    }
    public ILugar Lugar
    {
        get{
            if(_lugar == null){
                _lugar = new LugarRepository(context);
            }
            return _lugar;
        }
    }
    public IPersona Persona
    {
        get{
            if(_persona == null){
                _persona = new PersonaRepository(context);
            }
            return _persona;
        }
    }
    public ISalon Salon
    {
        get{
            if(_salon == null){
                _salon = new SalonRepository(context);
            }
            return _salon;
        }
    }
    public ITipoDocumento TipoDocumento
    {
        get{
            if(_tipoDocumento == null){
                _tipoDocumento = new TipoDocumentoRepository(context);
            }
            return _tipoDocumento;
        }
    }
    public ITipoInsidente TipoInsidente
    {
        get{
            if(_tipoInsidente == null){
                _tipoInsidente = new TipoInsidenteRepository(context);
            }
            return _tipoInsidente;
        }
    }
    public ITrainerPersona TrainerPersona
    {
        get{
            if(_trainerPersona == null){
                _trainerPersona = new TrainerPersonaRepository(context);
            }
            return _trainerPersona;
        }
    }
    public ITrainer Trainer
    {
        get{
            if(_trainer == null){
                _trainer = new TrainerRepository(context);
            }
            return _trainer;
        }
    }
    public void Dispose()
    {
        context.Dispose();
    }

    public Task<int> SaveAsync()
    {
        return context.SaveChangesAsync();
    }
}
