using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MouseShop.DAL.Interfaces;
using MouseShop.Service.Interfaces;

namespace MouseShop.Controllers;

public class MouseController : Controller
{
    private readonly IMouseService _mouseService;

    public MouseController(IMouseService mouseService)
    {
        _mouseService = mouseService;
    }

    [HttpGet]
    public async Task<IActionResult> GetMice()
    {
        var response = await _mouseService.GetMice();
        return View(response.Data);
    }
}