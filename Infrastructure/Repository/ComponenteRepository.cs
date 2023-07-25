
using System.Linq.Expressions;
using Core.Entities;
using Core.Interface;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class ComponenteRepository : IComponente
{
    // * ----- Constructor -----
    private readonly TechGuardianContext _context;
    
    public ComponenteRepository(TechGuardianContext context){
        _context = context;
    }
    // * ----- Interfaz -----
    public void Add(Componente entity)
    {
        _context.Set<Componente>().Add(entity);
    }

    public void AddRange(IEnumerable<Componente> entities)
    {
        _context.Set<Componente>().AddRange(entities);
    }

    public IEnumerable<Componente> Find(Expression<Func<Componente, bool>> expression)
    {
        return _context.Set<Componente>().Where(expression);
    }

    public async Task<IEnumerable<Componente>> GetAllAsync()
    {
        return await _context.Set<Componente>()
        .Include(p => p.EquipoComponentes)
        .ToListAsync();
    }

    public async Task<Componente> GetByIdAsync(int id)
    {
        return await _context.Set<Componente>()
        .Include(p => p.EquipoComponentes)
        .FirstOrDefaultAsync(p => p.id_componente == id);
    }

    public void Remove(Componente entity)
    {
        _context.Set<Componente>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<Componente> entities)
    {
        _context.Set<Componente>().RemoveRange(entities);
    }

    public void Update(Componente entity)
    {
        _context.Set<Componente>().Update(entity);
    }
}