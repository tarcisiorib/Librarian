namespace Librarian.Application.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string name, string key) : base($"{name} with key {key} not found")
    {
    }
}
