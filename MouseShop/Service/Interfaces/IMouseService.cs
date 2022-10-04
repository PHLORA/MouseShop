using MouseShop.Domain.Models;
using MouseShop.Domain.Response;

namespace MouseShop.Service.Interfaces;

public interface IMouseService
{
    Task<IBaseResponse<IEnumerable<Mouse>>> GetMice();
}