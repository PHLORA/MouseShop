using MouseShop.DAL.Interfaces;
using MouseShop.Domain.Enum;
using MouseShop.Domain.Models;
using MouseShop.Domain.Response;
using MouseShop.Service.Interfaces;

namespace MouseShop.Service.Implementations;

public class MouseService : IMouseService
{
    private readonly IMouseRepository _mouseRepository;

    public MouseService(IMouseRepository mouseRepository)
    {
        _mouseRepository = mouseRepository;
    }

    public async Task<IBaseResponse<IEnumerable<Mouse>>> GetMice()
    {
        var baseResponse = new BaseResponse<IEnumerable<Mouse>>();
        try
        {
            var mice = await _mouseRepository.Select();
            if (mice.Count == 0)
            {
                baseResponse.Description = "Найдено 0 элементов";
                baseResponse.StatusCode = StatusCode.DataNotFound;
            }

            baseResponse.Data = mice;
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        catch (Exception e)
        {
            return new BaseResponse<IEnumerable<Mouse>>()
            {
                Description = $"[GetMice] : {e.Message}"
            };
        }
    }
}