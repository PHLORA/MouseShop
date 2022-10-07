using BookShop.Domain.Models;

namespace BookShop.DAL.Interfaces;

public interface IBaseRepository<T>
{
    Task<bool> Create(T entity);

    Task<Book> Get(int id);

    Task<List<Book>> Select();

    Task<bool> Delete(T entity);

    Task<T> Update(T entity);
}