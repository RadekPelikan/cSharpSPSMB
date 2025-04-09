namespace RPGApp.DAL;

public class Enemy
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public int Health { get; set; }
    public int Damage { get; set; }
    public int Armor { get; set; }
    public float CriticalChance { get; set; }
    public float CriticalScaler { get; set; }

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}";
    }
}