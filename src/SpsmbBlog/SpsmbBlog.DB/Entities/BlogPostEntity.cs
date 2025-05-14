namespace SpsmbBlog.DB.Entities;

public class BlogPostEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; }
    public string Body { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateModified { get; set; }
}