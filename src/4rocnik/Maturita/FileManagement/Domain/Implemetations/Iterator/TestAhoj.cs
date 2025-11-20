using System.Collections;

namespace Iterator;

public class TestAhoj : TestIterator<TestAhoj>
{
    private TestAhoj _next;
    private string _text;

    public TestAhoj(string text, TestAhoj next = null)
    {
        _text = text;
        _next = next;
    }
    
    public bool HasNext()
    {
        return _next != null;
    }

    public TestAhoj Next()
    {
        return _next;
    }

    public string GetText()
    {
        return _text;
    }

    public IEnumerator<TestAhoj> GetEnumerator()
    {
        throw new NotImplementedException();
    }
}