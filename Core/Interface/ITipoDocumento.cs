using System.Linq.Expressions;
using Core.Entities;

namespace Core.Interface;

public interface ITipoDocumento
{
    //implemntacion de los metodos del CRUD para la entidad
    Task<TipoDocumento> GetByIdAsync(int id);
    Task<IEnumerable<TipoDocumento>> GetAllAsync();
    IEnumerable<TipoDocumento> Find(Expression<Func<TipoDocumento, bool>> expression);
    void Add(TipoDocumento entity);
    void AddRange(IEnumerable<TipoDocumento> entities);
    void Remove(TipoDocumento entity);
    void RemoveRange(IEnumerable<TipoDocumento> entities);
    void Update(TipoDocumento entity);
}