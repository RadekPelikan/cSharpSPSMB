

// Vytvořte record Dog, která dědí z Animal
// Vytvořte metodu DoSound na Animal, který printuje "Vrrr"
// u Dog přepište metodu DoSound()

// Vytvořte metodu na Animal, která vrátí počet končetin na bázi typu zvířete.
// int GetLimbs()

// Vytvořte metodu Move() na Animal, která vypíše: "Zvíře se pohnulo vpřed o 5 metrů"
// Udělejte override pro psa, který vypíše "Pes šel vpřed o 5 metrů"

// Udělejte overload pro Move(int meters) a bude vypisovat kolik metrů se pohnul

var animal = new Animal(AnimalGroup.Amphibians);
Console.WriteLine(animal.Group);

var a = new Dog();
Console.WriteLine(a.Group);

public enum AnimalGroup
{
    Fish,
    Reptiles,
    Birds,
    Mammals,
    Amphibians,
}

public record Animal
{
    public readonly AnimalGroup Group;

    public Animal(AnimalGroup group)
    {
        Group = group;
    }

    public Animal()
    {
    }
}

public record Dog : Animal
{
    public Dog() : base(AnimalGroup.Mammals)
    {
    }
}