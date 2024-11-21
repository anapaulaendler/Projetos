using Library.Models;

namespace Library.Interfaces;

public interface IBorrowable
{
    void Borrow(Member member, DateTime borrowDate);
    void Return(DateTime returnDate);
    bool IsBorrowed { get; }
}