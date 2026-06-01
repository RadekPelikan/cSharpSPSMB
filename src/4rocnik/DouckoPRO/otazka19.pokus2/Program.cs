// See https://aka.ms/new-console-template for more information

using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Otazka19;

Console.WriteLine("Hello, World!");

var context = new AppDbContext();

context.Database.Migrate();
// context.Database.EnsureCreated();


/**
 * Získá stránkované charaktery, dle velikosti stránky a kolikáté stránky
 * Charater se bude vždy vracet s jeho všemi zbraněmi
 */
List<CharacterEntity> GetCharactersPaginated(int pageSize, int page)
{
    var characters = context.Character
        .Include(e => e.Weapons)
        .Skip(page * pageSize)
        .Take(pageSize);

    return characters.ToList();
}

var seeder = new DBSeeder(context);
seeder.SeedRandomCharacters();
context.SaveChanges();

foreach (var characterEntity in GetCharactersPaginated(20, 0))
{
    Console.WriteLine($"{characterEntity.Name} - count: {characterEntity.Weapons.Count}");
}
