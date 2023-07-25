using System.Linq.Expressions;
using Core.Entities;

namespace Core.Interface;

public interface IComponente
{
    //implemntacion de los metodos del CRUD para la entidad
    Task<Componente> GetByIdAsync(int id);
    Task<IEnumerable<Componente>> GetAllAsync();
    IEnumerable<Componente> Find(Expression<Func<Componente, bool>> expression);
    void Add(Componente entity);
    void AddRange(IEnumerable<Componente> entities);
    void Remove(Componente entity);
    void RemoveRange(IEnumerable<Componente> entities);
    void Update(Componente entity);
}