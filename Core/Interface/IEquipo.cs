using System.Linq.Expressions;
using Core.Entities;

namespace Core.Interface;

public interface IEquipo
{
    //implemntacion de los metodos del CRUD para la entidad
    Task<Equipo> GetByIdAsync(int id);
    Task<IEnumerable<Equipo>> GetAllAsync();
    IEnumerable<Equipo> Find(Expression<Func<Equipo, bool>> expression);
    void Add(Equipo entity);
    void AddRange(IEnumerable<Equipo> entities);
    void Remove(Equipo entity);
    void RemoveRange(IEnumerable<Equipo> entities);
    void Update(Equipo entity);
}