namespace OopExamples.Interfaces.Exceptions;

public class ComponentAlreadyConnectedException : Exception
{
    public ComponentAlreadyConnectedException(string? message) : base(message)
    {
        throw new NotImplementedException(message);
    }
}