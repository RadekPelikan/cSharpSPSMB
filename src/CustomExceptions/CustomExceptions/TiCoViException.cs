namespace CustomExceptions;

public class TiCoViException : Exception
{
    private const string _customMessage = "Standa opet chybi";
    private readonly string _notTrueMessage = "Standa ma nulovou absenci";
    
    public TiCoViException(string? message) : base($"{_customMessage}: {message}")
    {
        
    }

    public TiCoViException(string? message, Exception? innerException) : base($"{_customMessage}: {message}", innerException)
    {
    }
}