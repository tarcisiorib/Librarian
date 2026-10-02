using Librarian.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Librarian.Persistence.Configurations;

public class MemberDatabaseInitialization : IEntityTypeConfiguration<Member>
{
    public void Configure(EntityTypeBuilder<Member> builder)
    {
        builder.HasData([
            new Member{
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "johndoe@teleworm.us",
                DateOfBirth = new DateTime(1988,5,3),
                PhoneNumber = "41991261632",
                PostalCode = "80230-000",
            },
            new Member{
                Id = 2,
                FirstName = "Sara",
                LastName = "Smith",
                Email = "sarasmith@armyspy.com",
                DateOfBirth = new DateTime(1976,3,15),
                PhoneNumber = "41991261632",
                PostalCode = "80230-010",
            }
        ]);

        builder.Property(m => m.FirstName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(m => m.LastName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(m => m.Email)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(m => m.PhoneNumber)
            .IsRequired()
            .HasMaxLength(11);

        builder.Property(m => m.PostalCode)
            .IsRequired()
            .HasMaxLength(9);

        builder.Property(m => m.DateOfBirth)
            .IsRequired();

        builder.Property(m => m.Id)
            .IsRequired()
            .UseIdentityColumn();

        builder.Property(m => m.CreatedAt)
            .IsRequired();
    }
}
