using System.Linq.Expressions;
using Core.Entities;

namespace Core.Interface;

public interface IArl
{
    //implemntacion de los metodos del CRUD para la entidad
    Task<Arl> GetByIdAsync(int id);
    Task<IEnumerable<Arl>> GetAllAsync();
    IEnumerable<Arl> Find(Expression<Func<Arl, bool>> expression);
    void Add(Arl entity);
    void AddRange(IEnumerable<Arl> entities);
    void Remove(Arl entity);
    void RemoveRange(IEnumerable<Arl> entities);
    void Update(Arl entity);
}
