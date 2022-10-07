using BookShop.Domain.Models;
using BookShop.Domain.Response;
using BookShop.Domain.ViewModels;

namespace BookShop.Service.Interfaces;

public interface IBookService
{
    Task<IBaseResponse<IEnumerable<Book>>> GetBooks();

    Task<IBaseResponse<Book>> GetBook(int id);
    Task<IBaseResponse<BookViewModel>> CreateBook(BookViewModel bookViewModel);
    Task<IBaseResponse<bool>> DeleteBook(int id);
    Task<IBaseResponse<Book>> GetBookByName(string name);

    Task<IBaseResponse<Book>> Edit(int id, BookViewModel model);
}