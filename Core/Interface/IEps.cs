using System.Linq.Expressions;
using Core.Entities;

namespace Core.Interface;

public interface IEps
{
    //implemntacion de los metodos del CRUD para la entidad
    Task<Eps> GetByIdAsync(int id);
    Task<IEnumerable<Eps>> GetAllAsync();
    IEnumerable<Eps> Find(Expression<Func<Eps, bool>> expression);
    void Add(Eps entity);
    void AddRange(IEnumerable<Eps> entities);
    void Remove(Eps entity);
    void RemoveRange(IEnumerable<Eps> entities);
    void Update(Eps entity);
}