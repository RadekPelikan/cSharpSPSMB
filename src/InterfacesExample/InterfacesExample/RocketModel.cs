namespace InterfacesExample;

public class RocketModel : IModel
{
    public Guid Id { get; }
    public string Name { get; set; }
    public DateOnly DateCreate { get; }
    public DateOnly DateModified { get; }
    
    public float Power { get; }

    public RocketModel(string name, float power)
    {
        Id = Guid.NewGuid();
        Name = name;
        Power = power;
        DateCreate = DateOnly.FromDateTime(DateTime.Now);
        DateModified = DateOnly.FromDateTime(DateTime.Now);
    }


    public string Describe()
    {
        return $"{Id}: {Name} [Power: {Power}]";
    }
}