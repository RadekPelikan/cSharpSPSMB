namespace ObjectOverrides;

public class Enemy
{
    public string Name;
    public double Hp;
    public double Damage;
    
    public virtual void Attack(Enemy enemy)
    {
        enemy.Hp -= this.Damage;
        Console.WriteLine($"Friendly fire na enemy {enemy.Name}");
    }
    
    // polymorphism[1] method overloading
    public virtual void Attack(Player player)
    {
        player.Hp -= this.Damage;
        Console.WriteLine($"Hraci {player.Name} bylo ubrano {this.Damage} Hp");
    }
}

public class Ogre : Enemy
{
    // polymorphism[2] method overriding
    public override void Attack(Enemy enemy)
    {
        enemy.Hp -= this.Damage * 1.2;
        Console.WriteLine($"Friendly fire na enemy {enemy.Name}");
    }

    // polymorphism[2] method overriding
    public override void Attack(Player player)
    {
        player.Hp -= this.Damage * 1.8;
        Console.WriteLine($"Hraci {player.Name} bylo ubrano {this.Damage} Hp");
    }
}

public class Player
{
    public string Name;
    public double Hp;
    public double Damage;
}