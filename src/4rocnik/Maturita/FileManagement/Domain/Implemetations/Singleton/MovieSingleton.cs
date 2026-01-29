namespace FileManagement.Domain.Implemetations;

public class MovieSingleton
{
    private static Movie? _instance = null;

    public static Movie? Instance => _instance;

    public static void CreateNewInstance(Movie movie) => _instance = movie;
}