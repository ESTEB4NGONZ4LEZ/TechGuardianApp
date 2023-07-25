using System.Linq.Expressions;
using Core.Entities;

namespace Core.Interface;

public interface IInsidente
{
    //implemntacion de los metodos del CRUD para la entidad
    Task<Insidente> GetByIdAsync(int id);
    Task<IEnumerable<Insidente>> GetAllAsync();
    IEnumerable<Insidente> Find(Expression<Func<Insidente, bool>> expression);
    void Add(Insidente entity);
    void AddRange(IEnumerable<Insidente> entities);
    void Remove(Insidente entity);
    void RemoveRange(IEnumerable<Insidente> entities);
    void Update(Insidente entity);
}