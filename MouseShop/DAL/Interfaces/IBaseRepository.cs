using MouseShop.Domain.Models;

namespace MouseShop.DAL.Interfaces;

public interface IBaseRepository<T>
{
    bool Create(T entity);

    T Get(int id);

    Task<List<Mouse>> Select();

    bool Delete(T entity);
}