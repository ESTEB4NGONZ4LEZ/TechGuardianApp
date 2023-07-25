using System.Linq.Expressions;
using Core.Entities;

namespace Core.Interface;

public interface ICamperPersona
{
    //implemntacion de los metodos del CRUD para la entidad
    Task<CamperPersona> GetByIdAsync(int id);
    Task<IEnumerable<CamperPersona>> GetAllAsync();
    IEnumerable<CamperPersona> Find(Expression<Func<CamperPersona, bool>> expression);
    void Add(CamperPersona entity);
    void AddRange(IEnumerable<CamperPersona> entities);
    void Remove(CamperPersona entity);
    void RemoveRange(IEnumerable<CamperPersona> entities);
    void Update(CamperPersona entity);
}