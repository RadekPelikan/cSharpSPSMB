public interface IPowerSupply
{
    int Wattage { get; }
}

public class PowerSupply : IPowerSupply
{
    public int Wattage { get; private set; }

    public PowerSupply(int wattage)
    {
        Wattage = wattage;
    }

    public override string ToString()
    {
        return $"{Wattage}W PSU";
    }
}