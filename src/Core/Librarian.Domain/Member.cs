using Librarian.Domain.Common;

namespace Librarian.Domain;

public class Member : Entity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
}
