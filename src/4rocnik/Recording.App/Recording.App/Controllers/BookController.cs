using Microsoft.AspNetCore.Mvc;
using Recording.App.Models;

namespace Recording.App.Controllers;

public class BookController : Controller
{
    private readonly ILogger<BookController> _logger;
    private static readonly List<Book> _books = new();

    public BookController(ILogger<BookController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CreateBook([FromForm] Book book)
    {
        _books.Add(book);
        string booksString = "";
        foreach (var book1 in _books)
        {
            booksString += $"{book1}, ";
        }

        _logger.LogInformation(booksString);

        return View("Index");
    }
}