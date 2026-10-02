using Librarian.Domain.Common;

namespace Librarian.Domain;

public class Book : Entity
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Author Author { get; set; } = new Author();
    public int AuthorId { get; set; }
    public DateTime PublishedDate { get; set; }
    public int Quantity { get; set; }
}
