using System.Data.Common;
using MySqlConnector;
using SpsmbBlog.DB.Entities;

namespace SpsmbBlog.DB.Repositories;

public class BlogRepository
{
    private DbDriver _dbDriver;

    public BlogRepository(DbDriver dbDriver)
    {
        _dbDriver = dbDriver;
    }

    public void Create(BlogPostEntity blogPostEntity)
    {
        using (MySqlConnection connection = _dbDriver.GetConnection())
        {
            connection.Open();
            string query = "INSERT INTO blog_post (id, title, body) VALUES (@id, @title, @body);";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", blogPostEntity.Id);
            command.Parameters.AddWithValue("@title", blogPostEntity.Title);
            command.Parameters.AddWithValue("@body", blogPostEntity.Body);
            command.ExecuteNonQuery();
        }
    }

    public List<BlogPostEntity> GetAll()
    {
        List<BlogPostEntity> blogPosts = new List<BlogPostEntity>();
        using (MySqlConnection connection = _dbDriver.GetConnection())
        {
            connection.Open();
            string query = "SELECT * FROM blog_post";
            MySqlCommand command = new MySqlCommand(query, connection);
            var reader = command.ExecuteReader();
            
            while (reader.Read())
            {
                var blogPost = new BlogPostEntity();
                blogPost.Id = Guid.Parse(reader.GetString(0));
                blogPost.Title = reader.GetString(1);
                blogPost.Body = reader.GetString(2);
                blogPost.DateCreated = reader.GetDateTime(3);
                blogPost.DateModified = reader.GetDateTime(4);
                blogPosts.Add(blogPost);
            }
        }
        
        return blogPosts;
    }

    public BlogPostEntity GetById(Guid id)
    {
        BlogPostEntity blogPostEntity;
        using (MySqlConnection connection = _dbDriver.GetConnection())
        {
            connection.Open();
            string query = "SELECT * FROM blog_post WHERE id = @id";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);
            var reader = command.ExecuteReader();
            reader.Read();
            blogPostEntity = new BlogPostEntity()
            {
                Id = reader.GetGuid(0),
                Title = reader.GetString(1),
                Body = reader.GetString(2),
                DateCreated = reader.GetDateTime(3),
                DateModified = reader.GetDateTime(4),
            };
        }
        return blogPostEntity;
    }
    
    
}