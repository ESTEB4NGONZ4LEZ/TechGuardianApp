
using System.Linq.Expressions;
using Core.Entities;
using Core.Interface;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class JornadaRepository : IJornada
{
    // * ----- Constructor -----
    private readonly TechGuardianContext _context;
    
    public JornadaRepository(TechGuardianContext context){
        _context = context;
    }
    // * ----- Interfaz -----
    public void Add(Jornada entity)
    {
        _context.Set<Jornada>().Add(entity);
    }

    public void AddRange(IEnumerable<Jornada> entities)
    {
        _context.Set<Jornada>().AddRange(entities);
    }

    public IEnumerable<Jornada> Find(Expression<Func<Jornada, bool>> expression)
    {
        return _context.Set<Jornada>().Where(expression);
    }

    public async Task<IEnumerable<Jornada>> GetAllAsync()
    {
        return await _context.Set<Jornada>()
        .Include(p => p.Personas)
        .ToListAsync();
    }

    public async Task<Jornada> GetByIdAsync(int id)
    {
        return await _context.Set<Jornada>()
        .Include(p => p.Personas)
        .FirstOrDefaultAsync(p => p.Id_jornada == id);
    }

    public void Remove(Jornada entity)
    {
        _context.Set<Jornada>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<Jornada> entities)
    {
        _context.Set<Jornada>().RemoveRange(entities);
    }

    public void Update(Jornada entity)
    {
        _context.Set<Jornada>().Update(entity);
    }
}