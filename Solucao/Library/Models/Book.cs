using Library.Interfaces;

namespace Library.Models;

public class Book : Item, IBorrowable
{
    public required string Author { get; set; }
    public required string Genre { get; set; }
    public bool IsBorrowed { get; set; }
    public string BorrowedStatus => IsBorrowed ? "Yes" : "No";
    public Member? BorrowedBy { get; set; }
    public DateTime? BorrowDate { get; set; }
    public DateTime? ReturnDate { get; set; }

    private const int BorrowDurationDays = 14;
    private const int FinePerDay = 3;

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
        ReturnDate = BorrowDate?.AddDays(BorrowDurationDays);
        IsBorrowed = true;

        Console.WriteLine($"Book '{Title}' borrowed by {member.Name} on {borrowDate.ToShortDateString()}. Return it until {ReturnDate?.ToShortDateString()}");
    }

    public void Return(DateTime returnDate)
    {
        if (!IsBorrowed)
        {
            Console.WriteLine("This book was not borrowed.");
            return;
        }

        int overdueDays = 0;

         if (ReturnDate.HasValue && returnDate > ReturnDate.Value)
        {
            overdueDays = (returnDate - ReturnDate.Value).Days;
        }       

        if (overdueDays < 0)
        {
            int fine = overdueDays * FinePerDay;
            BorrowedBy!.Fine += fine;

        Console.WriteLine($"Book returned late by {overdueDays} days. Fine imposed: ${overdueDays * 3}");
        }

        BorrowedBy = null;
        BorrowDate = null;
        ReturnDate = null;
        IsBorrowed = false;

        Console.WriteLine($"Book '{Title}' returned on {returnDate.ToShortDateString()}.");
    }
}