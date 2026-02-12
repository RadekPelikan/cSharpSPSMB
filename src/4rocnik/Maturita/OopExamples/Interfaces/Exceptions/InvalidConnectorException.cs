namespace OopExamples.Interfaces.Exceptions;

public class InvalidConnectorException : Exception
{
    public InvalidConnectorException(string? message) : base(message)
    {
        throw new NotImplementedException(message);
    }
}