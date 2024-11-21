using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers;

[ApiController]
[Route("api/book")]
public class BookController : ControllerBase
{
    private readonly AppDbContext _ctx;
    public BookController(AppDbContext ctx)
    {
        _ctx = ctx;
    } 


    [HttpPost("single")]
    public ActionResult<Book> PostBook(Book book)
    {
        _ctx.Add(book);
        _ctx.SaveChanges();

        return Ok(book);
    }

    [HttpPost("bulk")]
    public ActionResult<IEnumerable<Book>> PostBooks(List<Book> books)
    {
        _ctx.AddRange(books);
        _ctx.SaveChanges();

        return Ok(books);
    }

    [HttpGet]
    public ActionResult<IEnumerable<Book>> GetBooks()
    {
        return _ctx.Books.ToList();
    }

    [HttpGet("search")]
    public IActionResult GetBookByName(string name)
    {
        var books = _ctx.Books
            .Where(b => b.Title.Contains(name))
            .ToList();
        
        if (books is null)
        {
            return NotFound();
        }

        return Ok(books);
    }

    [HttpPut("update/({id})")]
    public ActionResult<Book> UpdateBook(Book updatedBook, int id)
    {
        var book = _ctx.Books.FirstOrDefault(b => b.Id == id);

        if (book is null)
        {
            return NotFound();
        }

        book.Author = updatedBook.Author;
        book.Genre = updatedBook.Genre;
        book.Title = updatedBook.Title;
        book.YearPublished = updatedBook.YearPublished;

        _ctx.Books.Update(book);
        _ctx.SaveChanges();
        return Ok(book);
    }

    [HttpPut("borrow/({idB})/({idM})")]
    public ActionResult<Book> BorrowBook(Book book, int idB, Guid idM)
    {
        var b = _ctx.Books.FirstOrDefault(b => b.Id == idB);

        if (b is null)
        {
            return NotFound("Book not found.");
        }

        Member? member = _ctx.Members.FirstOrDefault(m => m.Id == idM);

        if (member is null)
        {
            return NotFound("Member not found.");
        }

        DateTime d = DateTime.Now;

        b.Borrow(member, d);

        _ctx.Update(b);
        _ctx.SaveChanges();

        return Ok($"Book {b.Title} was borrowed by {member.Name} on {d.ToShortDateString()}.");
    }
}
