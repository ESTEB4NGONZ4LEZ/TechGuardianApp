
using System.Linq.Expressions;
using Core.Entities;
using Core.Interface;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class SalonRepository : ISalon
{
    // * ----- Constructor -----
    private readonly TechGuardianContext _context;
    
    public SalonRepository(TechGuardianContext context){
        _context = context;
    }
    // * ----- Interfaz -----
    public void Add(Salon entity)
    {
        _context.Set<Salon>().Add(entity);
    }

    public void AddRange(IEnumerable<Salon> entities)
    {
        _context.Set<Salon>().AddRange(entities);
    }

    public IEnumerable<Salon> Find(Expression<Func<Salon, bool>> expression)
    {
        return _context.Set<Salon>().Where(expression);
    }

    public async Task<IEnumerable<Salon>> GetAllAsync()
    {
        return await _context.Set<Salon>()
        .Include(p => p.Personas)
        .ToListAsync();
    }

    public async Task<Salon> GetByIdAsync(int id)
    {
        return await _context.Set<Salon>()
        .Include(p => p.Personas)
        .FirstOrDefaultAsync(p => p.Id_salon == id);
    }

    public void Remove(Salon entity)
    {
        _context.Set<Salon>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<Salon> entities)
    {
        _context.Set<Salon>().RemoveRange(entities);
    }

    public void Update(Salon entity)
    {
        _context.Set<Salon>().Update(entity);
    }
}