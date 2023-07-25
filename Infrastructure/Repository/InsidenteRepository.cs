
using System.Linq.Expressions;
using Core.Entities;
using Core.Interface;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class InsidenteRepository : IInsidente
{
    // * ----- Constructor -----
    private readonly TechGuardianContext _context;
    
    public InsidenteRepository(TechGuardianContext context){
        _context = context;
    }
    // * ----- Interfaz -----
    public void Add(Insidente entity)
    {
        _context.Set<Insidente>().Add(entity);
    }

    public void AddRange(IEnumerable<Insidente> entities)
    {
        _context.Set<Insidente>().AddRange(entities);
    }

    public IEnumerable<Insidente> Find(Expression<Func<Insidente, bool>> expression)
    {
        return _context.Set<Insidente>().Where(expression);
    }

    public async Task<IEnumerable<Insidente>> GetAllAsync()
    {
        return await _context.Set<Insidente>().ToListAsync();
    }

    public async Task<Insidente> GetByIdAsync(int id)
    {
        return await _context.Set<Insidente>().FindAsync(id);
    }

    public void Remove(Insidente entity)
    {
        _context.Set<Insidente>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<Insidente> entities)
    {
        _context.Set<Insidente>().RemoveRange(entities);
    }

    public void Update(Insidente entity)
    {
        _context.Set<Insidente>().Update(entity);
    }
}