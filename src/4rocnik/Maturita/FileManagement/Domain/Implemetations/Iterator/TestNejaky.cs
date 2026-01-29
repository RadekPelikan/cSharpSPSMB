namespace Iterator;

public class TestNejaky : TestIterator<TestNejaky>
{
    private TestNejaky _next;
    private string _name;

    public TestNejaky(string name, TestNejaky next = null)
    {
        _name = name;
        _next = next;
    }
    
    public bool HasNext()
    {
        return _next != null;
    }

    public TestNejaky Next()
    {
        return _next;
    }

    public string GetText()
    {
        return $"[TestNejaky] {_name}";
    }
}