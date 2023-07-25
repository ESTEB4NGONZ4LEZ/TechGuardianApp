
using System.Linq.Expressions;
using Core.Entities;
using Core.Interface;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class EpsRepository : IEps
{
    // * ----- Constructor -----
    private readonly TechGuardianContext _context;
    
    public EpsRepository(TechGuardianContext context){
        _context = context;
    }
    // * ----- Interfaz -----
    public void Add(Eps entity)
    {
        _context.Set<Eps>().Add(entity);
    }

    public void AddRange(IEnumerable<Eps> entities)
    {
        _context.Set<Eps>().AddRange(entities);
    }

    public IEnumerable<Eps> Find(Expression<Func<Eps, bool>> expression)
    {
        return _context.Set<Eps>().Where(expression);
    }

    public async Task<IEnumerable<Eps>> GetAllAsync()
    {
        return await _context.Set<Eps>()
        .Include(p => p.Campers)
        .ToListAsync();
    }

    public async Task<Eps> GetByIdAsync(int id)
    {
        return await _context.Set<Eps>()
        .Include(p => p.Campers)
        .FirstOrDefaultAsync(p => p.Id_arl == id);
    }

    public void Remove(Eps entity)
    {
        _context.Set<Eps>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<Eps> entities)
    {
        _context.Set<Eps>().RemoveRange(entities);
    }

    public void Update(Eps entity)
    {
        _context.Set<Eps>().Update(entity);
    }
}