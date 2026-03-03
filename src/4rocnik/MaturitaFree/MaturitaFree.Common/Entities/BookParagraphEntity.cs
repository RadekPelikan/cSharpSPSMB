namespace MaturitaFree.Common.Entities;

public record BookParagraphEntity : BaseEntity
{
    public string Content { get; set; }

    public int Order { get; set; }

    public int ChapterId { get; set; }
    public BookChapterEntity Chapter { get; set; }
}