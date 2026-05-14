public record Storage<T>
{
    public readonly T Data;
    public readonly DateTime CreatedAt;
    
    public Storage(T data)
    {
        Data = data;
        CreatedAt = DateTime.Now;
    }
}