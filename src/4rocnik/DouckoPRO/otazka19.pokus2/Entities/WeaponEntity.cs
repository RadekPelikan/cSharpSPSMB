public record WeaponEntity
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public int CharacterId { get; set; }
    
    public CharacterEntity Character { get; set; }
}