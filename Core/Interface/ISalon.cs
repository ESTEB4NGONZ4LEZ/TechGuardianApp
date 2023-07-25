using System.Linq.Expressions;
using Core.Entities;

namespace Core.Interface;

public interface ISalon
{
    //implemntacion de los metodos del CRUD para la entidad
    Task<Salon> GetByIdAsync(int id);
    Task<IEnumerable<Salon>> GetAllAsync();
    IEnumerable<Salon> Find(Expression<Func<Salon, bool>> expression);
    void Add(Salon entity);
    void AddRange(IEnumerable<Salon> entities);
    void Remove(Salon entity);
    void RemoveRange(IEnumerable<Salon> entities);
    void Update(Salon entity);
}