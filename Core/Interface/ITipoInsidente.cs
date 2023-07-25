using System.Linq.Expressions;
using Core.Entities;

namespace Core.Interface;

public interface ITipoInsidente
{
    //implemntacion de los metodos del CRUD para la entidad
    Task<TipoInsidente> GetByIdAsync(int id);
    Task<IEnumerable<TipoInsidente>> GetAllAsync();
    IEnumerable<TipoInsidente> Find(Expression<Func<TipoInsidente, bool>> expression);
    void Add(TipoInsidente entity);
    void AddRange(IEnumerable<TipoInsidente> entities);
    void Remove(TipoInsidente entity);
    void RemoveRange(IEnumerable<TipoInsidente> entities);
    void Update(TipoInsidente entity);
}