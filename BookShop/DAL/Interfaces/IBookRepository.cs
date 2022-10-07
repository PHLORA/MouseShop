using BookShop.Domain.Models;

namespace BookShop.DAL.Interfaces;

public interface IBookRepository : IBaseRepository<Book>
{
    Task<Book> GetByName(string name);
}