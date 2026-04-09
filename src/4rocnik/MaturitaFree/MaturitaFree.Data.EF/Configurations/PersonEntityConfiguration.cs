using MaturitaFree.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MaturitaFree.Data.EF.Configurations;

public sealed class PersonEntityConfiguration : BaseEntityConfiguration<PersonEntity>
{
    protected override void ConfigureEntity(EntityTypeBuilder<PersonEntity> builder)
    {
        builder.Property(e => e.FirstName)
            .IsRequired(false)
            .HasMaxLength(100);

        builder.Property(e => e.MiddleName)
            .IsRequired(false)
            .HasMaxLength(100);

        builder.Property(e => e.LastName)
            .IsRequired(false)
            .HasMaxLength(100);

        builder.Property(e => e.Pseudonym)
            .IsRequired(false)
            .HasMaxLength(200);

        builder.Property(e => e.Description)
            .IsRequired(false)
            .HasMaxLength(4000);

        builder.HasMany(e => e.WorkedOnBooks)
            .WithOne(w => w.Person)
            .HasForeignKey("PersonId")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
