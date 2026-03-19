namespace MaturitniZkouseni.Entities;

public record StudentEntity
{
// - id
    public int Id { get; set; }

// - name
    public string Name { get; set; }

// - ClassId
    public int ClassId { get; set; }

// - Class
    public ClassEntity Class { get; set; }
}