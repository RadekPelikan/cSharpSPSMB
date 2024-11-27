namespace InterfacesExample;

public interface IModel
{
    Guid Id { get; }
    string Name { get; set; }
    DateTime DateCreate { get; }
    DateTime DateModified { get;  }

    string Describe();
}