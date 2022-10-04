using MouseShop.Domain.Models;

namespace MouseShop.DAL.Interfaces;

public interface IMouseRepository : IBaseRepository<Mouse>
{
    Mouse GetByName(string name);
}