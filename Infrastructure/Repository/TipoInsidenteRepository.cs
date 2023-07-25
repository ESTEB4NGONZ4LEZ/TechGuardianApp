
using System.Linq.Expressions;
using Core.Entities;
using Core.Interface;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class TipoInsidenteRepository : ITipoInsidente
{
    // * ----- Constructor -----
    private readonly TechGuardianContext _context;
    
    public TipoInsidenteRepository(TechGuardianContext context){
        _context = context;
    }
    // * ----- Interfaz -----
    public void Add(TipoInsidente entity)
    {
        _context.Set<TipoInsidente>().Add(entity);
    }

    public void AddRange(IEnumerable<TipoInsidente> entities)
    {
        _context.Set<TipoInsidente>().AddRange(entities);
    }

    public IEnumerable<TipoInsidente> Find(Expression<Func<TipoInsidente, bool>> expression)
    {
        return _context.Set<TipoInsidente>().Where(expression);
    }

    public async Task<IEnumerable<TipoInsidente>> GetAllAsync()
    {
        return await _context.Set<TipoInsidente>()
        .Include(p => p.Insidentes)
        .ToListAsync();
    }

    public async Task<TipoInsidente> GetByIdAsync(int id)
    {
        return await _context.Set<TipoInsidente>()
        .Include(p => p.Insidentes)
        .FirstOrDefaultAsync(p => p.Id_tipo_insidente == id);
    }

    public void Remove(TipoInsidente entity)
    {
        _context.Set<TipoInsidente>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<TipoInsidente> entities)
    {
        _context.Set<TipoInsidente>().RemoveRange(entities);
    }

    public void Update(TipoInsidente entity)
    {
        _context.Set<TipoInsidente>().Update(entity);
    }
}