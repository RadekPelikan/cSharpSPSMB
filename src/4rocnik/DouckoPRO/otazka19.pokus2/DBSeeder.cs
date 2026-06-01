using Microsoft.EntityFrameworkCore;

namespace Otazka19;


#if true
public class DBSeeder(AppDbContext dbContext)
{
    public CharacterEntity AddRandomCharacter()
    {
        var randomCharacter = CreateRandomCharacter();

        dbContext.Character.Add(randomCharacter);
        dbContext.Entry(randomCharacter).State = EntityState.Detached;

        return randomCharacter;
    }

    public CharacterEntity AddRandomCharacterWithWeapon()
    {
        var randomCharacter = CreateRandomCharacter();

        dbContext.Character.Add(randomCharacter);
        for (int i = 1; i < Random.Shared.Next(10); i++)
        {
            AddRandomWeapon(randomCharacter);
        }

        return randomCharacter;
    }

    public WeaponEntity AddRandomWeapon(CharacterEntity character)
    {
        var randomWeapon = CreateRandomWeapon(character);

        dbContext.Weapon.Add(randomWeapon);

        return randomWeapon;
    }

    public void SeedRandomCharacters(int count = 100, double? percentage = null)
    {
        var characterWithWeaponPercentage =
            percentage is null
                ? Random.Shared.NextDouble()
                : percentage.Value;

        for (int i = 0; i < count; i++)
        {
            if (i < count * characterWithWeaponPercentage)
            {
                AddRandomCharacterWithWeapon();
            }
            else
            {
                AddRandomCharacter();
            }
        }
    }

    public void SeedRandomWeapons(int count = 100)
    {
        var character = AddRandomCharacter();

        for (int i = 0; i < count; i++)
        {
            AddRandomWeapon(character);
        }
    }

    public void Commit()
    {
        dbContext.SaveChanges();

        // Detach all tracked entities
        foreach (var entry in dbContext.ChangeTracker.Entries().ToList())
        {
            entry.State = EntityState.Detached;
        }
    }

    private CharacterEntity CreateRandomCharacter()
    {
        return new CharacterEntity()
        {
            Name = $"character-{Guid.NewGuid():N}",
            Weapons = new List<WeaponEntity>()
        };
    }

    private WeaponEntity CreateRandomWeapon(CharacterEntity character)
    {
        return new WeaponEntity()
        {
            Name = $"weapon-{Guid.NewGuid():N}",
            Character = character
        };
    }
}
#endif