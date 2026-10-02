using Librarian.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Librarian.Persistence.Configurations;

public class AuthorDatabaseInitialization : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.HasData([
            new Author {
                Id = 1,
                FirstName = "Yuval",
                LastName = "Harari",
                CreatedAt = DateTime.Now
            }
        ]);

        builder.Property(m => m.FirstName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(m => m.LastName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(m => m.Id)
            .IsRequired()
            .UseIdentityColumn();

        builder.Property(m => m.CreatedAt)
            .IsRequired();

        builder.Property(m => m.Id)
            .IsRequired()
            .UseIdentityColumn();
    }
}
