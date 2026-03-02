namespace MaturitaFree.Common.Entities;

public record PersonEntity : BaseEntity
{
    public string? FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string? LastName { get; set; }
    public string? Pseudonym { get; set; }
    public string? Description { get; set; }

    public ICollection<PersonWorkingOnBook> WorkedOnBooks { get; init; }
}