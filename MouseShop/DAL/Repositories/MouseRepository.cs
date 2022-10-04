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

    public bool Create(Mouse entity)
    {
        throw new NotImplementedException();
    }

    public Mouse Get(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Mouse>> Select()
    {
        return _db.Mice.ToListAsync();
    }

    public bool Delete(Mouse entity)
    {
        throw new NotImplementedException();
    }

    public Mouse GetByName(string name)
    {
        throw new NotImplementedException();
    }
}