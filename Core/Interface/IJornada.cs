using System.Linq.Expressions;
using Core.Entities;

namespace Core.Interface;

public interface IJornada
{
    //implemntacion de los metodos del CRUD para la entidad
    Task<Jornada> GetByIdAsync(int id);
    Task<IEnumerable<Jornada>> GetAllAsync();
    IEnumerable<Jornada> Find(Expression<Func<Jornada, bool>> expression);
    void Add(Jornada entity);
    void AddRange(IEnumerable<Jornada> entities);
    void Remove(Jornada entity);
    void RemoveRange(IEnumerable<Jornada> entities);
    void Update(Jornada entity);
}