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
        throw new NotImplementedException();
    }

    public BlogPost GetById(Guid id)
    {
        throw new NotImplementedException();
    }
    
    
}