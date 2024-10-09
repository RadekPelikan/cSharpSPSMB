# Rozsirite sve zadani SimpleEnemyFight

- splnění zadání: 100 bodů 
- bonusové body: 50 max
- odevzdat do **15.10.2024 23:59:59**

## Co bude obsahovat

- Naprogramujete hráče, kterej se bude moci ovládat příkazy z konzole
- Naprogramujete možnost hráče útočit na nepřítele a obráceně
- Naprogramujete systém zbraní, kde hráč bude moci sebrat zbraň a navyšovat mu nějaké schopnosti
- Naprogramujete systém healování skrze potiony (můžete přidat i potion na strength atd)
- Naprogramujete finálního bose, kterej bude mít 2 fáze útoků
- Dejte do toho RNG element, při otevření truhly v místnosti hráč třeba najde v místnosti Enemy místo nějakého meče
- Uděláte tam systém místností, kde hráč se bude moci pohybovat mezi různými místnostmi s vypisováním do konzole

## Sématické stylizování

- Každá třída, enum, struct, interface, ... bude ve vlastním souboru
- Třídy budou rozděleny na smysluplné složky/namespacy
- Využíjte Factory Design patternu

### Příklad Factory

```csharp
public class Enemy
{
    private string Name;
    private double BaseDmg;
    private double Hp;

    public Enemy(string name, double baseDmg, double hp)
    {
        Name = name;
        BaseDmg = baseDmg;
        Hp = hp;
    }

    public static class Factory
    {
        public static Enemy CreateOger()
        {
            return new Enemy("Oger", 5, 50);
        }

        public static Enemy CreateGoblin()
        {
            return new Enemy("Goblin", 7, 20);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        Enemy myOger = Enemy.Factory.CreateOger();
        Enemy goblin = Enemy.Factory.CreateGoblin();
    }
}
```

a nebo 

```csharp
public static class EnemyFactory
{
    public static Enemy CreateOger()
    {
        return new Enemy("Oger", 5, 50);
    }

    public static Enemy CreateGoblin()
    {
        return new Enemy("Goblin", 7, 20);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        Enemy myOger = EnemyFactory.CreateOger();
        Enemy goblin = EnemyFactory.CreateGoblin();
    }
}
```

