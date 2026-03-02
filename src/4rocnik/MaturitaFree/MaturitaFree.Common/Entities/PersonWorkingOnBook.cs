namespace MaturitaFree.Common.Entities;

public record PersonWorkingOnBook : BaseEntity
{
    public BookEntity Book { get; init; }

    public PersonEntity Person { get; init; }

    public string? Description { get; set; }

    public ContributorType Type { get; set; }
}