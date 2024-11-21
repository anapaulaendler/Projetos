namespace Library.Models;

public abstract class Item
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public int YearPublished { get; set; }

    public abstract void DisplayInfo();
}