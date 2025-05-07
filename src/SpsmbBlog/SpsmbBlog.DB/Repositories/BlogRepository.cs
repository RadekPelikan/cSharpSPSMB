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

    public void Create(BlogPost blogPost)
    {
        using (MySqlConnection connection = _dbDriver.GetConnection())
        {
            connection.Open();
            string query = "INSERT INTO blog_post (id, title, body) VALUES (@id, @title, @body);";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", blogPost.Id);
            command.Parameters.AddWithValue("@title", blogPost.Title);
            command.Parameters.AddWithValue("@body", blogPost.Body);
            command.ExecuteNonQuery();
        }
    }

    public List<BlogPost> GetAll()
    {
        List<BlogPost> blogPosts = new List<BlogPost>();
        using (MySqlConnection connection = _dbDriver.GetConnection())
        {
            connection.Open();
            string query = "SELECT * FROM blog_post";
            MySqlCommand command = new MySqlCommand(query, connection);
            var reader = command.ExecuteReader();
            
            while (reader.Read())
            {
                var blogPost = new BlogPost();
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

    public BlogPost GetById(Guid id)
    {
        BlogPost blogPost;
        using (MySqlConnection connection = _dbDriver.GetConnection())
        {
            connection.Open();
            string query = "SELECT * FROM blog_post WHERE id = @id";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);
            var reader = command.ExecuteReader();
            reader.Read();
            blogPost = new BlogPost()
            {
                Id = reader.GetGuid(0),
                Title = reader.GetString(1),
                Body = reader.GetString(2),
                DateCreated = reader.GetDateTime(3),
                DateModified = reader.GetDateTime(4),
            };
        }
        return blogPost;
    }
    
    
}