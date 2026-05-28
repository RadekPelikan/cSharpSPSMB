// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using Otazka19;

Console.WriteLine("Hello, World!");


var context = new AppDbContext();

// Jak aplikovat/zmigrovat databázi?
// Aplikujte migrace do databáze
context.Database.Migrate();


// Vytvořte funkci na získání všech Charakterů s jejich zbraněmi se stránkováním
// List<Character> GetCharactersPaginated(int pageSize, int page);

List<CharacterEntity> GetCharactersPaginated(int pageSize, int page)
{
    var characters = context.Character
        .Include(e => e.Weapons)
        .Skip(page * pageSize)
        .Take(pageSize);

    return characters.ToList();
}

// .Skip() .Take()

// zaznamu: 100
// pageSize = 20
// page = 0
// 0 - 19
// page = 1
// 20 - 39
// page = 2
// 40 - 59

var seeder = new DBSeeder(context);

seeder.SeedRandomCharacters();
context.SaveChanges();

const int PageSize = 20;

void PrintPage(int page)
{
    var characters = GetCharactersPaginated(PageSize, page);
    foreach (var character in characters)
    {
        Console.WriteLine($"{character.Name}: weapon count: {character.Weapons.Count}");
    }
}

var pageCount = context.Character.Count() / PageSize;
Console.WriteLine($"Pages: {pageCount}");
while (true)
{
    Console.Write("Enter page: ");
    var pageInput = Console.ReadLine();

    if (pageInput == "l")
    {
        Console.Clear();
    }
    
    if (pageInput == "q")
    {
        break;
    }

    if (int.TryParse(pageInput, out var page))
    {
        PrintPage(page);
    }
    else
    {
        Console.WriteLine("Invalid input!");
    }

    if (page > 0 || page > pageCount)
    {
        Console.WriteLine("Invalid page!");
    }
    Console.WriteLine($"Page: {page}/{pageCount}");
}
