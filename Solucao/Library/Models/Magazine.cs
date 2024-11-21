namespace Library.Models;

public class Magazine : Item
{
    public int IssueNumber { get; set; }
    public required string Publisher { get; set; }
    public override string DisplayInfo()
    {
        return $"Id: {Id}, Title: {Title}, Year Published: {YearPublished}, Issue Number: {IssueNumber}, Publisher: {Publisher}";
    }
}