using Microsoft.AspNetCore.Mvc;
using System;
using bogreol_api.Service;
using shared.Model;

namespace bogreol_api.Controllers;

[Controller]
[Route("api/[controller]")]
public class BookController : Controller
{
    private readonly MongoDBService _mongoDBService;

    public BookController(MongoDBService mongoDBService)
    {
        _mongoDBService = mongoDBService;
    }

    [HttpGet]
    public async Task<List<Book>> GetAll()
    {
        return await _mongoDBService.GetAsync();
    }

    [HttpPost]
    public async Task<IActionResult> PostBook(Book book)
    {
        await _mongoDBService.CreateBookAsync(book);
        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteBook(string id)
    {
        await _mongoDBService.DeleteAsync(id);
        return NoContent();
    }

}

