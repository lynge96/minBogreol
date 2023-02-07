using Microsoft.AspNetCore.Mvc;
using System;
using bogreol_api.Service;
using shared.Model;
using System.Linq;

namespace bogreol_api.Controllers;

[Controller]
[Route("api/[controller]")]
public class BookController : Controller
{
    private readonly MongoDBService _mongoDBService;
    private readonly ILogger<BookController> _logger;

    public BookController(MongoDBService mongoDBService, ILogger<BookController> logger)
    {
        _mongoDBService = mongoDBService;
        _logger = logger;
    }
    

    [HttpGet("allBooks")]
    public async Task<List<Book>> GetAll()
    {
        _logger.LogInformation("\nMethod: GetAll() called at {DT}", DateTime.UtcNow.ToLongTimeString());

        return await _mongoDBService.GetAllAsync();
    }


    [HttpPost("postBook")]
    public async Task<IActionResult> PostBook(Book newBook)
    {
        _logger.LogInformation("\nMethod: PostBook(Book newBook) called at {DT}", DateTime.UtcNow.ToLongTimeString());

        try
        {
            await _mongoDBService.CreateBookAsync(book: newBook);
            _logger.LogInformation($"\nBook: {newBook.Titel}, ID: {newBook.Id} - has been added to the database!");
            
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError("Fejlbesked: " + ex.Message);
        }

        return NoContent();
    }


    [HttpDelete("deleteBook")]
    public async Task<IActionResult> DeleteBook(string id)
    {
        _logger.LogInformation("\nMethod: DeleteBook(string id) called at {DT}", DateTime.UtcNow.ToLongTimeString());

        try
        {
            await _mongoDBService.DeleteAsync(id: id);
            _logger.LogInformation($"\nBook: {id} - has been deleted!");

            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError("Fejlbesked: " + ex.Message);
        }

        return NoContent();
    }

}

