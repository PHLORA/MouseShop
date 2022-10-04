using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MouseShop.DAL.Interfaces;

namespace MouseShop.Controllers;

public class MouseController : Controller
{
    private readonly IMouseRepository _mouseRepository;

    public MouseController(IMouseRepository mouseRepository)
    {
        _mouseRepository = mouseRepository;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetMice()
    {
        var response = await _mouseRepository.Select();
        return View(response);
    }
}