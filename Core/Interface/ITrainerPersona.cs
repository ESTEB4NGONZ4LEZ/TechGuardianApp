using System.Linq.Expressions;
using Core.Entities;

namespace Core.Interface;

public interface ITrainerPersona
{
    //implemntacion de los metodos del CRUD para la entidad
    Task<TrainerPersona> GetByIdAsync(int id);
    Task<IEnumerable<TrainerPersona>> GetAllAsync();
    IEnumerable<TrainerPersona> Find(Expression<Func<TrainerPersona, bool>> expression);
    void Add(TrainerPersona entity);
    void AddRange(IEnumerable<TrainerPersona> entities);
    void Remove(TrainerPersona entity);
    void RemoveRange(IEnumerable<TrainerPersona> entities);
    void Update(TrainerPersona entity);
}