namespace InterfacesExample;

public class CarModel : IModel, ICar
{
    public Guid Id { get; }
    public string Name { get; set; }
    public DateOnly DateCreate { get; }
    public DateOnly DateModified { get; }
    
    public string Brand { get; }

    public CarModel(string name, string brand)
    {
        Id = Guid.NewGuid();
        Name = name;
        Brand = brand;
        DateCreate = DateOnly.FromDateTime(DateTime.Now);
        DateModified = DateOnly.FromDateTime(DateTime.Now);
    }


    public string Describe()
    {
        return $"{Id}: {Brand}({Name})";
    }
}