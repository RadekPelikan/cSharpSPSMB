namespace InterfacesExample;

public class RocketModel : IModel
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
    
    public float Power { get; }

    public RocketModel(string name, float power)
    {
        Id = Guid.NewGuid();
        Name = name;
        Power = power;
        DateCreate = DateTime.Now;
        DateModified = DateTime.Now;
    }


    public string Describe()
    {
        return $"{Id}: {Name} [Power: {Power}]";
    }
}