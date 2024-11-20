namespace CustomExceptions;

public class TiCoViException : Exception
{
    public string Name;
    private const string _customMessage = $"opet chybi";

    public TiCoViException(string name)
    {
        Name = name;
    }
    
    public TiCoViException(string name, string? message) : base($"{name} {_customMessage}: {message}")
    {
        Name = name;
    }

    public TiCoViException(string name, string? message, Exception? innerException) : base($"{name} {_customMessage}: {message}", innerException)
    {
        Name = name;
    }
}