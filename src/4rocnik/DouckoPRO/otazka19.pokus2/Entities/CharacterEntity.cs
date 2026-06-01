public record CharacterEntity
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public ICollection<WeaponEntity> Weapons { get; set; }
}