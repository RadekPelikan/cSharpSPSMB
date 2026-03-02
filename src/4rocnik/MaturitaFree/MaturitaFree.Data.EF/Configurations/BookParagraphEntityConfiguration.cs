using MaturitaFree.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MaturitaFree.Data.EF.Configurations;

public sealed class BookParagraphEntityConfiguration : BaseEntityConfiguration<BookParagraphEntity>
{
    protected override void ConfigureEntity(EntityTypeBuilder<BookParagraphEntity> builder)
    {
        builder.Property(e => e.Content)
            .IsRequired();

        builder.Property(e => e.Order)
            .IsRequired();

        // Self-referencing parent paragraph (optional nesting)
        builder.HasOne(e => e.Paragraph)
            .WithMany()
            .HasForeignKey(e => e.ParagraphId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(e => e.ParagraphId)
            .HasDatabaseName("IX_BookParagraph_ParagraphId");

        builder.HasIndex("ChapterId")
            .HasDatabaseName("IX_BookParagraph_ChapterId");
    }
}
