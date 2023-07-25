using System.Linq.Expressions;
using Core.Entities;
using Core.Interface;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class TrainerRepository : ITrainer
{
    // * ----- Constructor -----
    private readonly TechGuardianContext _context;
    
    public TrainerRepository(TechGuardianContext context){
        _context = context;
    }
    // * ----- Interfaz -----
    public void Add(Trainer entity)
    {
        _context.Set<Trainer>().Add(entity);
    }

    public void AddRange(IEnumerable<Trainer> entities)
    {
        _context.Set<Trainer>().AddRange(entities);
    }

    public IEnumerable<Trainer> Find(Expression<Func<Trainer, bool>> expression)
    {
        return _context.Set<Trainer>().Where(expression);
    }

    public async Task<IEnumerable<Trainer>> GetAllAsync()
    {
        return await _context.Set<Trainer>()
        .Include(p => p.TrainerPersonas)
        .ToListAsync();
    }

    public async Task<Trainer> GetByIdAsync(int id)
    {
        return await _context.Set<Trainer>()
        .Include(p => p.TrainerPersonas)
        .FirstOrDefaultAsync(p => p.Id_trainer == id);
    }

    public void Remove(Trainer entity)
    {
        _context.Set<Trainer>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<Trainer> entities)
    {
        _context.Set<Trainer>().RemoveRange(entities);
    }

    public void Update(Trainer entity)
    {
        _context.Set<Trainer>().Update(entity);
    }
}