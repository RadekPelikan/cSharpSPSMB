namespace MaturitaFree.Common.Entities;

public abstract record BaseEntity
{
    public int Id { get; set; }

    public DateTime DateCreated { get; set; }
    public DateTime? DateModified { get; set; }
    public DateTime? DateDeleted { get; set; }
    public bool IsDeleted { get; set; }
}
