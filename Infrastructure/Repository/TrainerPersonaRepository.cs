

using System.Linq.Expressions;
using Core.Entities;
using Core.Interface;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class TrainerPersonaRepository : ITrainerPersona
{
    // * ----- Constructor -----
    private readonly TechGuardianContext _context;
    
    public TrainerPersonaRepository(TechGuardianContext context){
        _context = context;
    }
    // * ----- Interfaz -----
    public void Add(TrainerPersona entity)
    {
        _context.Set<TrainerPersona>().Add(entity);
    }

    public void AddRange(IEnumerable<TrainerPersona> entities)
    {
        _context.Set<TrainerPersona>().AddRange(entities);
    }

    public IEnumerable<TrainerPersona> Find(Expression<Func<TrainerPersona, bool>> expression)
    {
        return _context.Set<TrainerPersona>().Where(expression);
    }

    public async Task<IEnumerable<TrainerPersona>> GetAllAsync()
    {
        return await _context.Set<TrainerPersona>().ToListAsync();
    }

    public async Task<TrainerPersona> GetByIdAsync(int id)
    {
        return await _context.Set<TrainerPersona>().FindAsync(id);
    }

    public void Remove(TrainerPersona entity)
    {
        _context.Set<TrainerPersona>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<TrainerPersona> entities)
    {
        _context.Set<TrainerPersona>().RemoveRange(entities);
    }

    public void Update(TrainerPersona entity)
    {
        _context.Set<TrainerPersona>().Update(entity);
    }
}