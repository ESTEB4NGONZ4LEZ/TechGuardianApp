using System.Linq.Expressions;
using Core.Entities;

namespace Core.Interface;

public interface IEquipoLugar
{
    //implemntacion de los metodos del CRUD para la entidad
    Task<EquipoLugar> GetByIdAsync(int id);
    Task<IEnumerable<EquipoLugar>> GetAllAsync();
    IEnumerable<EquipoLugar> Find(Expression<Func<EquipoLugar, bool>> expression);
    void Add(EquipoLugar entity);
    void AddRange(IEnumerable<EquipoLugar> entities);
    void Remove(EquipoLugar entity);
    void RemoveRange(IEnumerable<EquipoLugar> entities);
    void Update(EquipoLugar entity);
}