using System.Linq.Expressions;
using Core.Entities;

namespace Core.Interface;

public interface ICamper
{
    //implemntacion de los metodos del CRUD para la entidad
    Task<Camper> GetByIdAsync(int id);
    Task<IEnumerable<Camper>> GetAllAsync();
    IEnumerable<Camper> Find(Expression<Func<Camper, bool>> expression);
    void Add(Camper entity);
    void AddRange(IEnumerable<Camper> entities);
    void Remove(Camper entity);
    void RemoveRange(IEnumerable<Camper> entities);
    void Update(Camper entity);
}