namespace OopExamples.Interfaces.Exceptions;

public class ComponentNotConnectedException : Exception
{
    public ComponentNotConnectedException(string? message) : base(message)
    {
        throw new NotImplementedException(message);
    }
}