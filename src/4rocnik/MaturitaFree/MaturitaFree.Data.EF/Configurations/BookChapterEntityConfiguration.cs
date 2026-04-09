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
        
        builder.HasMany(e => e.Paragraphs)
            .WithOne(c => c.Chapter)
            .HasForeignKey(c => c.ChapterId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
