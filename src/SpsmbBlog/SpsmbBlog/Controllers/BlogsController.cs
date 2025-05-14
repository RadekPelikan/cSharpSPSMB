using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SpsmbBlog.DB.Entities;
using SpsmbBlog.DB.Repositories;
using SpsmbBlog.Models;

namespace SpsmbBlog.Controllers;

public class BlogsController : Controller
{
    private const int SummaryWordCount = 20;
    private readonly ILogger<IndexController> _logger;
    private readonly BlogRepository _blogRepository;

    public BlogsController(ILogger<IndexController> logger, BlogRepository blogRepository)
    {
        _logger = logger;
        _blogRepository = blogRepository;
    }

    public IActionResult Index()
    {
        var blogPosts = _blogRepository.GetAll();

        BlogSummaryListViewModel model = new BlogSummaryListViewModel
        {
            BlogPosts = blogPosts.Select<BlogPostEntity, BlogSummaryViewModel>(blogPost =>
                new BlogSummaryViewModel()
                {
                    Id = blogPost.Id,
                    Title = blogPost.Title,
                    Body = $"{StripBody(blogPost.Body)}...",
                })
        };
        return View(model);
    }

    private string StripBody(string body) =>
        string.Join(" ", body.Split("\n").First().Trim().Split(" ").Take(SummaryWordCount));

    public IActionResult New()
    {
        return View(new NewBlogViewModel());
    }


    [HttpGet("blogs/{id:guid}")]
    public IActionResult Detail(Guid id)
    {
        _logger.LogInformation($"Blog Id: {id}");

        var blogPost = _blogRepository.GetById(id);
        
        return View(new BlogDetailViewModel
        {
            Id = blogPost.Id,
            Title = blogPost.Title,
            Body = blogPost.Body,
            DateCreated = blogPost.DateCreated,
            DateModified = blogPost.DateModified,
        });
    }

    [HttpPost("/blogs/new")]
    public IActionResult New([FromForm] NewBlogViewModel newBlog)
    {
        if (string.IsNullOrEmpty(newBlog.Title))
            return BadRequest();
        if (string.IsNullOrEmpty(newBlog.Body))
            return BadRequest();

        _blogRepository.Create(new BlogPostEntity()
        {
            Title = newBlog.Title,
            Body = newBlog.Body,
        });

        return RedirectToAction("Index", "Blogs");
    }


    [HttpPost, ActionName("Delete")]
    public IActionResult Delete(Guid id)
    {
        Console.WriteLine($"Deleting blog with id: {id}");

        return RedirectToAction("Index", "Blogs");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}