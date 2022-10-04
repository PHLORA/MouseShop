using Microsoft.EntityFrameworkCore;
using MouseShop.DAL.Interfaces;
using MouseShop.Domain.Models;

namespace MouseShop.DAL.Repositories;

public class MouseRepository : IMouseRepository
{

    private readonly ApplicationDbContext _db;

    public MouseRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<bool> Create(Mouse entity)
    {
        await _db.Mice.AddAsync(entity);
        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<Mouse> Get(int id)
    {
        return await _db.Mice.FirstOrDefaultAsync(x => x.ID_mouse == id);
    }

    public Task<List<Mouse>> Select()
    {
        return _db.Mice.ToListAsync();
    }

    public async Task<bool> Delete(Mouse entity)
    {
        _db.Mice.Remove(entity);
        await _db.SaveChangesAsync();
        
        return true;
    }

    public async Task<Mouse> GetByName(string name)
    {
        return await _db.Mice.FirstOrDefaultAsync(x => x.Name == name);
    }
}