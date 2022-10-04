using MouseShop.Domain.Models;

namespace MouseShop.DAL.Interfaces;

public interface IBaseRepository<T>
{
    Task<bool> Create(T entity);

    Task<Mouse> Get(int id);

    Task<List<Mouse>> Select();

    Task<bool> Delete(T entity);
}