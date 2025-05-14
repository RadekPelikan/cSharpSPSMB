namespace SpsmbBlog.Models;

public class BlogDetailViewModel
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateModified { get; set; }
}
