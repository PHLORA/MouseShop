using BookShop.DAL.Interfaces;
using BookShop.Domain.Enum;
using BookShop.Domain.Models;
using BookShop.Domain.Response;
using BookShop.Domain.ViewModels;
using BookShop.Service.Interfaces;

namespace BookShop.Service.Implementations;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<IBaseResponse<BookViewModel>> CreateBook(BookViewModel bookViewModel)
    {
        var baseResponse = new BaseResponse<BookViewModel>();
        try
        {
            var book = new Book()
            {
                Name = bookViewModel.Name,
                Description = bookViewModel.Description,
                Price = bookViewModel.Price,
                isDel = bookViewModel.isDel,
                Author = bookViewModel.Author,
                Genre = bookViewModel.Genre,
                Language = bookViewModel.Language, 
                Cover = bookViewModel.Cover
            };

            await _bookRepository.Create(book);
        }
        catch (Exception e)
        {
            return new BaseResponse<BookViewModel>()
            {
                Description = $"[CreateBook] : {e.Message}"
            };
        }

        return baseResponse;
    }
    public async Task<IBaseResponse<Book>> GetBook(int id)
    {
        var baseResponse = new BaseResponse<Book>();
        try
        {
            var book = await _bookRepository.Get(id);
            if (book == null)
            {
                baseResponse.Description = "Book not found.";
                baseResponse.StatusCode = StatusCode.MouseNotFound;
                return baseResponse;
            }

            baseResponse.Data = book;
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        catch (Exception e)
        {
            return new BaseResponse<Book>()
            {
                Description = $"[GetBook] : {e.Message}"
            };
        }
    }
    public async Task<IBaseResponse<Book>> GetBookByName(string name)
    {
        var baseResponse = new BaseResponse<Book>();
        try
        {
            var book = await _bookRepository.GetByName(name);
            if (book == null)
            {
                baseResponse.Description = "Book not found.";
                baseResponse.StatusCode = StatusCode.MouseNotFound;
                return baseResponse;
            }

            baseResponse.Data = book;
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        catch (Exception e)
        {
            return new BaseResponse<Book>()
            {
                Description = $"[GetBookByName] : {e.Message}"
            };
        }
    }

    public async Task<IBaseResponse<Book>> Edit(int id, BookViewModel model)
    {
        var baseResponse = new BaseResponse<Book>();
        try
        {
            var book = await _bookRepository.Get(id);
            if (book == null)
            {
                baseResponse.Description = "Book not found.";
                baseResponse.StatusCode = StatusCode.MouseNotFound;
                return baseResponse;
            }

            book.Name = model.Name;
            book.Description = model.Description;
            book.Price = model.Price;
            book.isDel = model.isDel;
            book.Author = model.Author;
            book.Genre = model.Genre;
            book.Language = model.Language;
            book.Cover = model.Cover;

            await _bookRepository.Update(book);

            return baseResponse;
        }
        catch (Exception e)
        {
            return new BaseResponse<Book>()
            {
                Description = $"[Edit] : {e.Message}"
            };
        }
    }

    public async Task<IBaseResponse<bool>> DeleteBook(int id)
    {
        var baseResponse = new BaseResponse<bool>();
        try
        {
            var book = await _bookRepository.Get(id);
            if (book == null)
            {
                baseResponse.Description = "Book not found.";
                baseResponse.StatusCode = StatusCode.MouseNotFound;
                return baseResponse;
            }

            await _bookRepository.Delete(book);
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        catch (Exception e)
        {
            return new BaseResponse<bool>()
            {
                Description = $"[DeleteBook] : {e.Message}"
            };
        }
    }
    public async Task<IBaseResponse<IEnumerable<Book>>> GetBooks()
    {
        var baseResponse = new BaseResponse<IEnumerable<Book>>();
        try
        {
            var books = await _bookRepository.Select();
            if (books.Count == 0)
            {
                baseResponse.Description = "Найдено 0 элементов";
                baseResponse.StatusCode = StatusCode.DataNotFound;
                return baseResponse;
            }

            baseResponse.Data = books;
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        catch (Exception e)
        {
            return new BaseResponse<IEnumerable<Book>>()
            {
                Description = $"[GetBooks] : {e.Message}"
            };
        }
    }
}