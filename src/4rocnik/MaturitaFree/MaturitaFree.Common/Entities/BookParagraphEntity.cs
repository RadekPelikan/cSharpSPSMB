namespace MaturitaFree.Common.Entities;

public record BookParagraphEntity : BaseEntity
{
    public string Content { get; set; }

    public int Order { get; set; }

    public int ParagraphId { get; set; }
    public BookParagraphEntity Paragraph { get; set; }
}