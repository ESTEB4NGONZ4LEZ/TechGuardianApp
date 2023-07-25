
using System.Linq.Expressions;
using Core.Entities;
using Core.Interface;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class TipoDocumentoRepository : ITipoDocumento
{
    // * ----- Constructor -----
    private readonly TechGuardianContext _context;
    
    public TipoDocumentoRepository(TechGuardianContext context){
        _context = context;
    }
    // * ----- Interfaz -----
    public void Add(TipoDocumento entity)
    {
        _context.Set<TipoDocumento>().Add(entity);
    }

    public void AddRange(IEnumerable<TipoDocumento> entities)
    {
        _context.Set<TipoDocumento>().AddRange(entities);
    }

    public IEnumerable<TipoDocumento> Find(Expression<Func<TipoDocumento, bool>> expression)
    {
        return _context.Set<TipoDocumento>().Where(expression);
    }

    public async Task<IEnumerable<TipoDocumento>> GetAllAsync()
    {
        return await _context.Set<TipoDocumento>()
        .Include(p => p.Personas)
        .ToListAsync();
    }

    public async Task<TipoDocumento> GetByIdAsync(int id)
    {
        return await _context.Set<TipoDocumento>()
        .Include(p => p.Personas)
        .FirstOrDefaultAsync(p => p.Id_tipo_documento == id);
    }

    public void Remove(TipoDocumento entity)
    {
        _context.Set<TipoDocumento>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<TipoDocumento> entities)
    {
        _context.Set<TipoDocumento>().RemoveRange(entities);
    }

    public void Update(TipoDocumento entity)
    {
        _context.Set<TipoDocumento>().Update(entity);
    }
}