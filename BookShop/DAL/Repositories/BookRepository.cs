using BookShop.DAL.Interfaces;
using BookShop.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShop.DAL.Repositories;

public class BookRepository : IBookRepository
{

    private readonly ApplicationDbContext _db;

    public BookRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<bool> Create(Book entity)
    {
        await _db.Books.AddAsync(entity);
        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<Book> Get(int id)
    {
        return await _db.Books.FirstOrDefaultAsync(x => x.Id == id);
    }

    public Task<List<Book>> Select()
    {
        return _db.Books.ToListAsync();
    }

    public async Task<bool> Delete(Book entity)
    {
        _db.Books.Remove(entity);
        await _db.SaveChangesAsync();
        
        return true;
    }

    public async Task<Book> Update(Book entity)
    {
        _db.Books.Update(entity);
        await _db.SaveChangesAsync();

        return entity;
    }

    public async Task<Book> GetByName(string name)
    {
        return await _db.Books.FirstOrDefaultAsync(x => x.Name == name);
    }
}