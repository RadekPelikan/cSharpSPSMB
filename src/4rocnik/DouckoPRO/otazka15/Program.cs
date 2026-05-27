// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

/**
 * Vytvořte Factory:
 *
 * enum TerrainType:
 * - Forest
 * - Desert
 * - Snow
 * - Volcano
 * - Swamp
 *
 * record Map
 * - string Name
 * - TerrainType Terrain
 * - int MaxPlayers
 * - int ThreatLevel
 *
 * static class MapStaticFactory
 * - static CreateDeathForest()
 * - static CreatePeacefulDesert()
 * - static CreateFrozenMountain()
 * - static CreateLightSwamp()
 *
 * class MapPresetFactory
 * constructor:
 * MapPresetFactory(int MaxPlayers)
 *
 * - CreateDeathForest()
 * - CreatePeacefulDesert()
 * - CreateFrozenMountain()
 * - CreateLightSwamp()
 */


/**
 * Vytvořte builder:
 *
 * enum CharacterClass
 * - Warrior
 * - Mage
 * - Archer
 *
 * class Character
 * - string Name
 * - CharacterClass Class
 * - int MaxHealth
 * - int MaxMana
 * - int Strength
 * - class Builder bude vne class Character
 * - class Builder
 * - - SetName(string name)
 * - - SetClass(CharacterClass class)
 * - - SetMaxHealth(int maxHealth)
 * - - SetMaxMana(int maxMana)
 * - - SetStrength(int strength)
 * - - Build() -> vraci instanci Character
 */