namespace EFCoreVirgin.Common.Model;

public record ListModel<T>
{
    public int Count => Items?.Count ?? 0;
    public List<T>? Items { get; set; } = new List<T>();
}