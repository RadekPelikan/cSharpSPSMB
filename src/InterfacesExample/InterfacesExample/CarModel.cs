namespace InterfacesExample;

public class CarModel : IModel, ICar
{
    public Guid Id { get; }
    private string _name;
    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            DateModified = DateTime.Now;
        }
    }

    public DateTime DateCreate { get; }
    public DateTime DateModified { get; private set; }
    
    public string Brand { get; }

    public CarModel(string name, string brand)
    {
        Id = Guid.NewGuid();
        Name = name;
        Brand = brand;
        DateCreate = DateTime.Now;
        DateModified = DateTime.Now;
    }


    public string Describe()
    {
        return $"{Id}: {Brand}({Name})";
    }
}