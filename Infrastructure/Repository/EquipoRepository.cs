
using System.Linq.Expressions;
using Core.Entities;
using Core.Interface;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class EquipoRepository : IEquipo
{
    // * ----- Constructor -----
    private readonly TechGuardianContext _context;
    
    public EquipoRepository(TechGuardianContext context){
        _context = context;
    }
    // * ----- Interfaz -----
    public void Add(Equipo entity)
    {
        _context.Set<Equipo>().Add(entity);
    }

    public void AddRange(IEnumerable<Equipo> entities)
    {
        _context.Set<Equipo>().AddRange(entities);
    }

    public IEnumerable<Equipo> Find(Expression<Func<Equipo, bool>> expression)
    {
        return _context.Set<Equipo>().Where(expression);
    }

    public async Task<IEnumerable<Equipo>> GetAllAsync()
    {
        return await _context.Set<Equipo>()
        .Include(p => p.EquipoComponentes)
        .Include(p => p.EquipoLugares)
        .ToListAsync();
    }

    public async Task<Equipo> GetByIdAsync(int id)
    {
        return await _context.Set<Equipo>()
        .Include(p => p.EquipoComponentes)
        .Include(p => p.EquipoLugares)
        .FirstOrDefaultAsync(p => p.Id_equipo == id);
    }

    public void Remove(Equipo entity)
    {
        _context.Set<Equipo>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<Equipo> entities)
    {
        _context.Set<Equipo>().RemoveRange(entities);
    }

    public void Update(Equipo entity)
    {
        _context.Set<Equipo>().Update(entity);
    }
}