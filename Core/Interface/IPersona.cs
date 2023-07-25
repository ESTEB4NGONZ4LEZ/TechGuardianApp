using System.Linq.Expressions;
using Core.Entities;

namespace Core.Interface;

public interface IPersona
{
    //implemntacion de los metodos del CRUD para la entidad
    Task<Persona> GetByIdAsync(int id);
    Task<IEnumerable<Persona>> GetAllAsync();
    IEnumerable<Persona> Find(Expression<Func<Persona, bool>> expression);
    void Add(Persona entity);
    void AddRange(IEnumerable<Persona> entities);
    void Remove(Persona entity);
    void RemoveRange(IEnumerable<Persona> entities);
    void Update(Persona entity);
}