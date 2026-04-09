using MaturitaFree.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MaturitaFree.Data.EF.Configurations;

public sealed class BookEntityConfiguration : BaseEntityConfiguration<BookEntity>
{
    protected override void ConfigureEntity(EntityTypeBuilder<BookEntity> builder)
    {
        builder.Property(e => e.Title)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(e => e.Description)
            .IsRequired(false)
            .HasMaxLength(4000);

        builder.HasMany(e => e.Chapters)
            .WithOne(c => c.Book)
            .HasForeignKey(c => c.BookId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(e => e.Contributers)
            .WithOne(c => c.Book)
            .HasForeignKey("BookId")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
