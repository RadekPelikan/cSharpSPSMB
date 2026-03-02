using MaturitaFree.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MaturitaFree.Data.EF.Configurations;

public sealed class BookChapterEntityConfiguration : BaseEntityConfiguration<BookChapterEntity>
{
    protected override void ConfigureEntity(EntityTypeBuilder<BookChapterEntity> builder)
    {
        builder.Property(e => e.Title)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(e => e.Order)
            .IsRequired();

        builder.HasOne(e => e.Book)
            .WithMany(b => b.Chapters)
            .HasForeignKey(e => e.BookId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(e => e.BookId)
            .HasDatabaseName("IX_BookChapter_BookId");

        // Unique order per book — no two chapters can share the same position
        builder.HasIndex(e => new { e.BookId, e.Order })
            .IsUnique()
            .HasDatabaseName("UX_BookChapter_BookId_Order");

        builder.HasMany(e => e.Paragraphs)
            .WithOne()
            .HasForeignKey("ChapterId")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
