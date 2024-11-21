namespace Library.Models;

public class Author
{
    public required string Name { get; set; }
    public List<Book>? Books { get; set; }
    
}