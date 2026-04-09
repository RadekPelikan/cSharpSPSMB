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

        builder.HasIndex(e => e.BookId);
        builder.HasIndex(e => e.PersonId);

        builder.Property(e => e.Description)
            .IsRequired(false)
            .HasMaxLength(2000);

        builder.Property(e => e.Type)
            .IsRequired()
            .HasConversion<string>();
        
        builder.HasOne(e => e.Book)
            .WithMany(c => c.Contributers)
            .HasForeignKey(c => c.BookId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(e => e.Person)
            .WithMany(c => c.WorkedOnBooks)
            .HasForeignKey(c => c.PersonId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
