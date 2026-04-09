namespace MaturitaFree.Common.Entities;

public record BookChapterEntity : BaseEntity
{
    public string Title { get; set; }

    public int Order { get; set; }

    public int BookId { get; set; }
    public BookEntity Book { get; set; }

    public ICollection<BookParagraphEntity> Paragraphs { get; init; }
}