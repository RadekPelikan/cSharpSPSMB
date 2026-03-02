using MaturitaFree.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MaturitaFree.Data.EF.Configurations;

public sealed class PersonWorkingOnBookConfiguration : BaseEntityConfiguration<PersonWorkingOnBook>
{
    protected override void ConfigureEntity(EntityTypeBuilder<PersonWorkingOnBook> builder)
    {
        // Explicit shadow FK properties so we can index them
        builder.Property<int>("BookId").IsRequired();
        builder.Property<int>("PersonId").IsRequired();

        builder.HasOne(e => e.Book)
            .WithMany(b => b.Contributers)
            .HasForeignKey("BookId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Person)
            .WithMany(p => p.WorkedOnBooks)
            .HasForeignKey("PersonId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(e => e.Description)
            .IsRequired(false)
            .HasMaxLength(2000);

        builder.Property(e => e.Type)
            .IsRequired()
            .HasConversion<string>();

        // Indexes on both FK columns for fast lookup in either direction
        builder.HasIndex("BookId")
            .HasDatabaseName("IX_PersonWorkingOnBook_BookId");

        builder.HasIndex("PersonId")
            .HasDatabaseName("IX_PersonWorkingOnBook_PersonId");

        // Composite index — useful for "is this person already contributing to this book?" checks
        builder.HasIndex("BookId", "PersonId")
            .HasDatabaseName("IX_PersonWorkingOnBook_BookId_PersonId");
    }
}
