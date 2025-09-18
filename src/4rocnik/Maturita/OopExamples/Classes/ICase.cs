public interface ICase
{
    string Model { get; }
    string Size { get; }
}

public class Case : ICase
{
    public string Model { get; private set; }
    public string Size { get; private set; }

    public Case(string model, string size)
    {
        Model = model;
        Size = size;
    }

    public override string ToString()
    {
        return $"{Model} ({Size})";
    }
}