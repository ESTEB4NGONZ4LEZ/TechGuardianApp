
using System.Linq.Expressions;
using Core.Entities;
using Core.Interface;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class ArlRepository : IArl
{
    // * ----- Constructor -----
    private readonly TechGuardianContext _context;
    
    public ArlRepository(TechGuardianContext context){
        _context = context;
    }
    // * ----- Interfaz -----
    public void Add(Arl entity)
    {
        _context.Set<Arl>().Add(entity);
    }

    public void AddRange(IEnumerable<Arl> entities)
    {
        _context.Set<Arl>().AddRange(entities);
    }

    public IEnumerable<Arl> Find(Expression<Func<Arl, bool>> expression)
    {
        return _context.Set<Arl>().Where(expression);
    }

    public async Task<IEnumerable<Arl>> GetAllAsync()
    {
        return await _context.Set<Arl>()
        .Include(p => p.Trainers)
        .ToListAsync();
    }

    public async Task<Arl> GetByIdAsync(int id)
    {
        return await _context.Set<Arl>()
        .Include(p => p.Trainers)
        .FirstOrDefaultAsync(p => p.Id_arl == id);
    }

    public void Remove(Arl entity)
    {
        _context.Set<Arl>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<Arl> entities)
    {
        _context.Set<Arl>().RemoveRange(entities);
    }

    public void Update(Arl entity)
    {
        _context.Set<Arl>().Update(entity);
    }
}