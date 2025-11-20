namespace FileManagement;

public interface IMovieRepository
{
    void Save(List<Movie> movies);
    List<Movie> GetAll();
}