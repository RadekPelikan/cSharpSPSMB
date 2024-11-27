namespace InterfacesExample;

public interface IModel
{
    Guid Id { get; }
    string Name { get; set; }
    DateOnly DateCreate { get; }
    DateOnly DateModified { get;  }

    string Describe();
}

public interface ICar
{
    string Brand { get; }
}