namespace MaturitaFree.Common.Entities;

public record BookEntity : BaseEntity
{
    public string Title { get; set; }

    public string Description { get; set; }

    public ICollection<BookChapterEntity> Chapters { get; init; }

    public ICollection<PersonWorkingOnBook> Contributers { get; init; }
}