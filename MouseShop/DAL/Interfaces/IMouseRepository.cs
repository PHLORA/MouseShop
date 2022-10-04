using MouseShop.Domain.Models;

namespace MouseShop.DAL.Interfaces;

public interface IMouseRepository : IBaseRepository<Mouse>
{
    Task<Mouse> GetByName(string name);
}