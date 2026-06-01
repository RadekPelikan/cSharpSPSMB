// See https://aka.ms/new-console-template for more information

using otazka04;

Console.WriteLine("Hello, World!");

// Vytvořte record Person, který obsahuje Name a Age



// Ontogenetické fáze
// Vytvořte switch expression, který dle věku určí fázi vývoje člověka

// Run.Task01(new Person("Pepa", 18));

object pepa = GetObject();

if (pepa is Person person)
{
    Console.WriteLine($"Pepa je person name: {person.Name}");
}

if (pepa is string pepaString)
{
    Console.WriteLine($"Pepa je string delka: {pepaString.Length}");
}

const int i = 100;
var value = i switch
{
    < 5 => "ahoj",
    _ => "nic"
};

object GetObject()
{
    return "pepa";
    return new Person("pepa", 12);
}