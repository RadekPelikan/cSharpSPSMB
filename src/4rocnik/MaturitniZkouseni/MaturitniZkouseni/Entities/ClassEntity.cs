namespace MaturitniZkouseni.Entities;

public record ClassEntity
{
// - id
    public int Id { get; set; }

// - name
    public string Name { get; set; }

// - ICollection<StudentEntity> Students
    public ICollection<StudentEntity> Students { get; set; }
}