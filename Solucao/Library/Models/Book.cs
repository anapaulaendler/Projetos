using Library.Interfaces;

namespace Library.Models;

public class Book : Item, IBorrowable
{
    public required string Author { get; set; }
    public required string Genre { get; set; }
    public bool IsBorrowed { get; private set; }
    public string BorrowedStatus => IsBorrowed ? "Yes" : "No";
    public Member? BorrowedBy { get; private set; }
    public DateTime? BorrowDate { get; private set; }
    public DateTime? ReturnDate { get; private set; }

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

        Console.WriteLine($"Book '{Title}' borrowed by {member.Name} on {borrowDate.ToShortDateString()}. Return it until {ReturnDate?.ToShortDateString()}");
    }

    public void Return(DateTime returnDate)
    {
        if (!IsBorrowed)
        {
            Console.WriteLine("This book was not borrowed.");
            return;
        }

        if(ReturnDate is null) return;

        int r = DateTime.Compare((DateTime)ReturnDate, returnDate);

        if (r < 0)
        {

            int overdueDays = r * (-1);
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