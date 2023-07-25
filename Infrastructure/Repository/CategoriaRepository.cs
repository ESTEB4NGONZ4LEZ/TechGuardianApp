
using System.Linq.Expressions;
using Core.Entities;
using Core.Interface;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class CategoriaRepository : ICategoria
{
    // * ----- Constructor -----
    private readonly TechGuardianContext _context;
    
    public CategoriaRepository(TechGuardianContext context){
        _context = context;
    }
    // * ----- Interfaz -----
    public void Add(Categoria entity)
    {
        _context.Set<Categoria>().Add(entity);
    }

    public void AddRange(IEnumerable<Categoria> entities)
    {
        _context.Set<Categoria>().AddRange(entities);
    }

    public IEnumerable<Categoria> Find(Expression<Func<Categoria, bool>> expression)
    {
        return _context.Set<Categoria>().Where(expression);
    }

    public async Task<IEnumerable<Categoria>> GetAllAsync()
    {
        return await _context.Set<Categoria>()
        .Include(p => p.Insidentes)
        .ToListAsync();
    }

    public async Task<Categoria> GetByIdAsync(int id)
    {
        return await _context.Set<Categoria>()
        .Include(p => p.Insidentes)
        .FirstOrDefaultAsync(p => p.Id_categoria == id);
    }

    public void Remove(Categoria entity)
    {
        _context.Set<Categoria>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<Categoria> entities)
    {
        _context.Set<Categoria>().RemoveRange(entities);
    }

    public void Update(Categoria entity)
    {
        _context.Set<Categoria>().Update(entity);
    }
}