
using System.Linq.Expressions;
using Core.Entities;
using Core.Interface;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class CamperPersonaRepository : ICamperPersona
{
    // * ----- Constructor -----
    private readonly TechGuardianContext _context;
    
    public CamperPersonaRepository(TechGuardianContext context){
        _context = context;
    }
    // * ----- Interfaz -----
    public void Add(CamperPersona entity)
    {
        _context.Set<CamperPersona>().Add(entity);
    }

    public void AddRange(IEnumerable<CamperPersona> entities)
    {
        _context.Set<CamperPersona>().AddRange(entities);
    }

    public IEnumerable<CamperPersona> Find(Expression<Func<CamperPersona, bool>> expression)
    {
        return _context.Set<CamperPersona>().Where(expression);
    }

    public async Task<IEnumerable<CamperPersona>> GetAllAsync()
    {
        return await _context.Set<CamperPersona>().ToListAsync();
    }

    public async Task<CamperPersona> GetByIdAsync(int id)
    {
        return await _context.Set<CamperPersona>().FindAsync(id);
    }

    public void Remove(CamperPersona entity)
    {
        _context.Set<CamperPersona>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<CamperPersona> entities)
    {
        _context.Set<CamperPersona>().RemoveRange(entities);
    }

    public void Update(CamperPersona entity)
    {
        _context.Set<CamperPersona>().Update(entity);
    }
}