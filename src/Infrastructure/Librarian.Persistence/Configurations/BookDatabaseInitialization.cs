using Librarian.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Librarian.Persistence.Configurations;

public class BookDatabaseInitialization : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.Property(b => b.Title)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(b => b.Description)
            .HasMaxLength(150);

        builder.Property(b => b.AuthorId)
            .IsRequired();
        
        builder.Property(b => b.PublishedDate)
            .IsRequired();

        builder.Property(b => b.Quantity)
            .IsRequired();

        builder.HasOne(b => b.Author)
            .WithMany(a => a.Books)
            .HasForeignKey(b => b.AuthorId);

        builder.Property(m => m.Id)
            .IsRequired()
            .UseIdentityColumn();
    }
}
