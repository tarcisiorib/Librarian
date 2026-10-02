using Librarian.Domain.Common;

namespace Librarian.Domain;

public class Author : Entity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public IEnumerable<Book> Books { get; set; } = new List<Book>();
}