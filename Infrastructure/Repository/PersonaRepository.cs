
using System.Linq.Expressions;
using Core.Entities;
using Core.Interface;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class PersonaRepository : IPersona
{
    // * ----- Constructor -----
    private readonly TechGuardianContext _context;
    
    public PersonaRepository(TechGuardianContext context){
        _context = context;
    }
    // * ----- Interfaz -----
    public void Add(Persona entity)
    {
        _context.Set<Persona>().Add(entity);
    }

    public void AddRange(IEnumerable<Persona> entities)
    {
        _context.Set<Persona>().AddRange(entities);
    }

    public IEnumerable<Persona> Find(Expression<Func<Persona, bool>> expression)
    {
        return _context.Set<Persona>().Where(expression);
    }

    public async Task<IEnumerable<Persona>> GetAllAsync()
    {
        return await _context.Set<Persona>()
        .Include(p => p.Insidentes)
        .Include(p => p.TrainerPersonas)
        .Include(p => p.CamperPersonas)
        .ToListAsync();
    }

    public async Task<Persona> GetByIdAsync(int id)
    {
        return await _context.Set<Persona>()
        .Include(p => p.Insidentes)
        .Include(p => p.TrainerPersonas)
        .Include(p => p.CamperPersonas)
        .FirstOrDefaultAsync(p => p.Id_persona == id);
    }

    public void Remove(Persona entity)
    {
        _context.Set<Persona>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<Persona> entities)
    {
        _context.Set<Persona>().RemoveRange(entities);
    }

    public void Update(Persona entity)
    {
        _context.Set<Persona>().Update(entity);
    }
}