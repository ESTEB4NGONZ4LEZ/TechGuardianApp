using System.Linq.Expressions;
using Core.Entities;

namespace Core.Interface;

public interface IEquipoComponente
{
    //implemntacion de los metodos del CRUD para la entidad
    Task<EquipoComponente> GetByIdAsync(int id);
    Task<IEnumerable<EquipoComponente>> GetAllAsync();
    IEnumerable<EquipoComponente> Find(Expression<Func<EquipoComponente, bool>> expression);
    void Add(EquipoComponente entity);
    void AddRange(IEnumerable<EquipoComponente> entities);
    void Remove(EquipoComponente entity);
    void RemoveRange(IEnumerable<EquipoComponente> entities);
    void Update(EquipoComponente entity);
}