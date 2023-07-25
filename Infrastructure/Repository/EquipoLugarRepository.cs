
using System.Linq.Expressions;
using Core.Entities;
using Core.Interface;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class EquipoLugarRepository : IEquipoLugar
{
    // * ----- Constructor -----
    private readonly TechGuardianContext _context;
    
    public EquipoLugarRepository(TechGuardianContext context){
        _context = context;
    }
    // * ----- Interfaz -----
    public void Add(EquipoLugar entity)
    {
        _context.Set<EquipoLugar>().Add(entity);
    }

    public void AddRange(IEnumerable<EquipoLugar> entities)
    {
        _context.Set<EquipoLugar>().AddRange(entities);
    }

    public IEnumerable<EquipoLugar> Find(Expression<Func<EquipoLugar, bool>> expression)
    {
        return _context.Set<EquipoLugar>().Where(expression);
    }

    public async Task<IEnumerable<EquipoLugar>> GetAllAsync()
    {
        return await _context.Set<EquipoLugar>().ToListAsync();
    }

    public async Task<EquipoLugar> GetByIdAsync(int id)
    {
        return await _context.Set<EquipoLugar>().FindAsync(id);
    }

    public void Remove(EquipoLugar entity)
    {
        _context.Set<EquipoLugar>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<EquipoLugar> entities)
    {
        _context.Set<EquipoLugar>().RemoveRange(entities);
    }

    public void Update(EquipoLugar entity)
    {
        _context.Set<EquipoLugar>().Update(entity);
    }
}