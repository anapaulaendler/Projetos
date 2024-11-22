using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        _ctx.Books.Add(book);
        _ctx.SaveChanges();

        return Ok(book);
    }

    [HttpPost("bulk")]
    public ActionResult<IEnumerable<Book>> PostBooks(List<Book> books)
    {
        _ctx.Books.AddRange(books);
        _ctx.SaveChanges();

        return Ok(books);
    }

    [HttpGet]
    public ActionResult<IEnumerable<Book>> GetBooks()
    {
        return _ctx.Books.ToList();
    }

    [HttpGet("search/{name}")]
    public ActionResult<IEnumerable<string>> GetBookByName(string name)
    {
        var books = _ctx.Books
            .Where(b => b.Title.ToLower().Contains(name.ToLower()))
            .ToList()
            .Select(x => x.DisplayInfo())
            .ToList();
        
        if (books is null)
        {
            return NotFound();
        }

        return books;
    }

    [HttpGet("{id}")]
    public ActionResult<string> GetBookById(int id)
    {
        Book? b = _ctx.Books
            .FirstOrDefault(b => b.Id == id);
        
        if (b is null)
        {
            return NotFound();
        }

        return b.DisplayInfo();
    }

    [HttpGet("report/borrowed")]
    public ActionResult<IEnumerable<string>> GetBorrowedBooks()
    {
        var books = _ctx.Books
            .Where(b => b.IsBorrowed)
            .ToList()
            .Select(x => x.DisplayInfo())
            .ToList();
        
        if (books is null)
        {
            return NotFound();
        }

        return books;
    }

    [HttpPut("update/{id}")]
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

    [HttpPut("borrow/{idB}/{idM}")]
    public ActionResult<Book> BorrowBook([FromRoute] int idB, [FromRoute] Guid idM)
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

        if (b.IsBorrowed)
        {
            return BadRequest("Book is already borrowed.");
        }

        DateTime d = DateTime.Now;

        b.Borrow(member, d);

        _ctx.Books.Update(b);
        _ctx.SaveChanges();

        return Ok($"Book {b.Title} was borrowed by {b.BorrowedBy!.Name} on {d.ToShortDateString()}.");
    }

    [HttpPut("return/{idB}/{returnDate}")]
    public ActionResult<Book> ReturnBook(int idB, DateTime returnDate)
    {
        var b = _ctx.Books
            .Include(x => x.BorrowedBy) 
            .FirstOrDefault(b => b.Id == idB);

        if (b is null)
        {
            return NotFound("Book not found.");
        }

        if (!b.IsBorrowed)
        {
            return BadRequest("Book isn't borrowed.");
        }

        if (b.BorrowedBy is null)
        {
            return NotFound("BorrowedBy not found.");
        }

        b.Return(returnDate);
        var member = _ctx.Members.FirstOrDefault(x => x.Id == b.BorrowedBy.Id);

        if (member is null)
        {
            return NotFound("Member wasn't found.");
        }
        
        b.NullBook(b);

        _ctx.Members.Update(member);
        _ctx.Books.Update(b);
        _ctx.SaveChanges();

        return Ok();    
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBook(int id)
    {
        var b = _ctx.Books.FirstOrDefault(b => b.Id == id);

        if (b is null)
        {
            return NotFound("Book not found.");
        }

        _ctx.Books.Remove(b);
        _ctx.SaveChanges();

        return NoContent();
    }

    [HttpGet("who/{id}")]
    public ActionResult<Member> GetBorrowedBook(int id)
    {
        var b = _ctx.Books
        .Include(x => x.BorrowedBy) 
            .FirstOrDefault(b => b.Id == id);

        if (b is null)
        {
            return NotFound("Book not found.");
        }

        if (b.BorrowedBy is null)
        {
            return NotFound("BorrowedBy not found.");
        }

        var member = _ctx.Members.FirstOrDefault(x => x.Id == b.BorrowedBy.Id);

        if (member is null)
        {
            return NotFound("Member wasn't found.");
        }

        return member;
    }
}