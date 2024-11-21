using Library.Interfaces;

namespace Library.Models;

public class Book : Item, IBorrowable
{
    public required string Author { get; set; }
    public required string Genre { get; set; }
    public bool IsBorrowed { get; private set; }
    public string BorrowedStatus => IsBorrowed ? "Yes" : "No";
    private Member? BorrowedBy {get; set; }
    private DateTime? BorrowDate { get; set; }
    private DateTime? ReturnDate { get; set; }

    public override string DisplayInfo()
    {
        return $"Id: {Id}, Title: {Title}, Year Published: {YearPublished}, Author: {Author}, Genre: {Genre}, Borrowed: {BorrowedStatus}";
    }

    public void Borrow(Member member, DateTime borrowDate)
    {
        if (IsBorrowed)
        {
            Console.WriteLine("This book is already borrowed.");
            return;
        }

        BorrowedBy = member;
        BorrowDate = borrowDate;
        ReturnDate = BorrowDate?.AddDays(14);
        IsBorrowed = true;

        Console.WriteLine($"Book '{Title}' borrowed by {member.Name} on {borrowDate.ToShortDateString()}.");
    }

    // public string IsBookBorrowed()
    // {
    //     return $"Book {Title} is borrowed by {BorrowedBy} and its return date is {ReturnDate}.";
    // }
    public void Return(DateTime returnDate)
    {
        if (!IsBorrowed)
        {
            Console.WriteLine("This book was not borrowed.");
            return;
        }

    if (ReturnDate.HasValue && returnDate > ReturnDate.Value)
    {

        int overdueDays = (returnDate - ReturnDate.Value).Days;
        BorrowedBy!.Fine += overdueDays * 3;

    Console.WriteLine($"Book returned late by {overdueDays} days. Fine imposed: ${overdueDays * 3}");
    }

        BorrowedBy = null;
        BorrowDate = null;
        ReturnDate = null;
        IsBorrowed = false;

        Console.WriteLine($"Book '{Title}' returned on {returnDate.ToShortDateString()}.");
    }
}