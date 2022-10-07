using BookShop.Domain.ViewModels;
using BookShop.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using BookShop.DAL.Interfaces;
using BookShop.Domain.Response;

namespace BookShop.Controllers;

public class BookController : Controller
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public async Task<IActionResult> GetBooks()
    {
        var response = await _bookService.GetBooks();
        if (response.StatusCode == Domain.Enum.StatusCode.OK)
        {
            return View(response.Data.ToList());
        }

        return RedirectToAction("Error");
    }

    [HttpGet]
    public async Task<IActionResult> GetBook(int id)
    {
        var response = await _bookService.GetBook(id);
        if (response.StatusCode == Domain.Enum.StatusCode.OK)
        {
            return View(response.Data);
        }

        return RedirectToAction("Error");
    }
    
    [Authorize(Roles= "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await _bookService.DeleteBook(id);
        if (response.StatusCode == Domain.Enum.StatusCode.OK)
        {
            return RedirectToAction("GetBooks");
        }

        return RedirectToAction("Error");
    }

    [HttpGet]
    [Authorize(Roles= "Admin")]
    public async Task<IActionResult> Save(int id)
    {
        if (id == 0)
        {
            return View();
        }

        var response = await _bookService.GetBook(id);
        if (response.StatusCode == Domain.Enum.StatusCode.OK)
        {
            return View(response.Data);
        }

        return RedirectToAction("Error");
    }

    [HttpPost]
    public async Task<IActionResult> Save(BookViewModel model)
    {
        if (ModelState.IsValid)
        {
            if (model.Id == 0)
            {
                await _bookService.CreateBook(model);
            }
            else
            {
                await _bookService.Edit(model.Id, model);
            }
        }

        return RedirectToAction("GetBooks");
    }
    
}