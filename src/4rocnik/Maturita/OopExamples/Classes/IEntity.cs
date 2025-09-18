public interface IEntity
{
    Guid Id { get; }
}

public abstract class BaseEntity : IEntity
{
    public Guid Id { get; private set; }

    public BaseEntity()
    {
        Id = Guid.NewGuid();
    }
}
