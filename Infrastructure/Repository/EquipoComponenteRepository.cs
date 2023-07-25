
using System.Linq.Expressions;
using Core.Entities;
using Core.Interface;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class EquipoComponenteRepository : IEquipoComponente
{
    // * ----- Constructor -----
    private readonly TechGuardianContext _context;
    
    public EquipoComponenteRepository(TechGuardianContext context){
        _context = context;
    }
    // * ----- Interfaz -----
    public void Add(EquipoComponente entity)
    {
        _context.Set<EquipoComponente>().Add(entity);
    }

    public void AddRange(IEnumerable<EquipoComponente> entities)
    {
        _context.Set<EquipoComponente>().AddRange(entities);
    }

    public IEnumerable<EquipoComponente> Find(Expression<Func<EquipoComponente, bool>> expression)
    {
        return _context.Set<EquipoComponente>().Where(expression);
    }

    public async Task<IEnumerable<EquipoComponente>> GetAllAsync()
    {
        return await _context.Set<EquipoComponente>().ToListAsync();
    }

    public async Task<EquipoComponente> GetByIdAsync(int id)
    {
        return await _context.Set<EquipoComponente>().FindAsync(id);
    }

    public void Remove(EquipoComponente entity)
    {
        _context.Set<EquipoComponente>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<EquipoComponente> entities)
    {
        _context.Set<EquipoComponente>().RemoveRange(entities);
    }

    public void Update(EquipoComponente entity)
    {
        _context.Set<EquipoComponente>().Update(entity);
    }
}