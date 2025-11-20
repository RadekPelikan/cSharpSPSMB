namespace Iterator;

public interface TestIterator<T>
{
    public bool HasNext();
    public T Next();
    public string GetText();
}