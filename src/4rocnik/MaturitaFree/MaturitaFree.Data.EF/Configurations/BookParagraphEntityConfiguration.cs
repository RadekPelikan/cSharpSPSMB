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
    }
}
