
using System.Linq.Expressions;
using Core.Entities;
using Core.Interface;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class LugarRepository : ILugar
{
    // * ----- Constructor -----
    private readonly TechGuardianContext _context;
    
    public LugarRepository(TechGuardianContext context){
        _context = context;
    }
    // * ----- Interfaz -----
    public void Add(Lugar entity)
    {
        _context.Set<Lugar>().Add(entity);
    }

    public void AddRange(IEnumerable<Lugar> entities)
    {
        _context.Set<Lugar>().AddRange(entities);
    }

    public IEnumerable<Lugar> Find(Expression<Func<Lugar, bool>> expression)
    {
        return _context.Set<Lugar>().Where(expression);
    }

    public async Task<IEnumerable<Lugar>> GetAllAsync()
    {
        return await _context.Set<Lugar>().ToListAsync();
    }

    public async Task<Lugar> GetByIdAsync(int id)
    {
        return await _context.Set<Lugar>().FindAsync(id);
    }

    public void Remove(Lugar entity)
    {
        _context.Set<Lugar>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<Lugar> entities)
    {
        _context.Set<Lugar>().RemoveRange(entities);
    }

    public void Update(Lugar entity)
    {
        _context.Set<Lugar>().Update(entity);
    }
}