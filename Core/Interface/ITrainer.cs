using System.Linq.Expressions;
using Core.Entities;

namespace Core.Interface;

public interface ITrainer
{
    //implemntacion de los metodos del CRUD para la entidad
    Task<Trainer> GetByIdAsync(int id);
    Task<IEnumerable<Trainer>> GetAllAsync();
    IEnumerable<Trainer> Find(Expression<Func<Trainer, bool>> expression);
    void Add(Trainer entity);
    void AddRange(IEnumerable<Trainer> entities);
    void Remove(Trainer entity);
    void RemoveRange(IEnumerable<Trainer> entities);
    void Update(Trainer entity);
}