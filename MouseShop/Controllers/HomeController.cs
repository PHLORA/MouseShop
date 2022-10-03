using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MouseShop.Domain.Models;
using MouseShop.Models;

namespace MouseShop.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        Mouse mouse = new Mouse()
        {
            Name = "SteelSeries Sensei Ten",
            Producer = "Razor"
        };
        return View(mouse);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}