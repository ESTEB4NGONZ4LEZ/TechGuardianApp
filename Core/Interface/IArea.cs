
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Interface;

public interface IArea
{
    //implemntacion de los metodos del CRUD para la entidad
    Task<Area> GetByIdAsync(int id);
    Task<IEnumerable<Area>> GetAllAsync();
    IEnumerable<Area> Find(Expression<Func<Area, bool>> expression);
    void Add(Area entity);
    void AddRange(IEnumerable<Area> entities);
    void Remove(Area entity);
    void RemoveRange(IEnumerable<Area> entities);
    void Update(Area entity);
}
