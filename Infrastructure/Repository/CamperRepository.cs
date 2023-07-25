
using System.Linq.Expressions;
using Core.Entities;
using Core.Interface;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class CamperRepository : ICamper
{
    // * ----- Constructor -----
    private readonly TechGuardianContext _context;
    
    public CamperRepository(TechGuardianContext context){
        _context = context;
    }
    // * ----- Interfaz -----
    public void Add(Camper entity)
    {
        _context.Set<Camper>().Add(entity);
    }

    public void AddRange(IEnumerable<Camper> entities)
    {
        _context.Set<Camper>().AddRange(entities);
    }

    public IEnumerable<Camper> Find(Expression<Func<Camper, bool>> expression)
    {
        return _context.Set<Camper>().Where(expression);
    }

    public async Task<IEnumerable<Camper>> GetAllAsync()
    {
        return await _context.Set<Camper>()
        .Include(p => p.CamperPersonas)
        .ToListAsync();
    }

    public async Task<Camper> GetByIdAsync(int id)
    {
        return await _context.Set<Camper>()
        .Include(p => p.CamperPersonas)
        .FirstOrDefaultAsync(p => p.Id_camper == id);
    }

    public void Remove(Camper entity)
    {
        _context.Set<Camper>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<Camper> entities)
    {
        _context.Set<Camper>().RemoveRange(entities);
    }

    public void Update(Camper entity)
    {
        _context.Set<Camper>().Update(entity);
    }
}