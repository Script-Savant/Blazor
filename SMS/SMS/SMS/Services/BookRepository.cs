using Microsoft.EntityFrameworkCore;
using SMS.Data;
using SMS.Shared.Interfaces;
using SMS.Shared.Models;

namespace SMS.Services;

public class BookRepository : IBookRepository
{
    private readonly ApplicationDbContext _db;

    public BookRepository(ApplicationDbContext db)
    {
        _db = db;
    }
    
    public async Task<List<Book>> GetBooks()
    {
        return await _db.Books.ToListAsync();
    }

    public async Task<Book> GetBook(int id)
    {
        var book = await _db.Books.FindAsync(id);
        if (book == null)
        {
            throw new KeyNotFoundException();
        }

        return book;
    }

    public async Task<Book> AddBook(Book book)
    {
        if (book == null)
        {
            throw new ArgumentNullException(nameof(book));
        }
        _db.Books.Add(book);
        await _db.SaveChangesAsync();
        
        return book;
    }

    public async Task<Book> UpdateBook(int id, Book book)
    {
        if (book == null)
        {
            throw new ArgumentNullException(nameof(book));
        }
        _db.Books.Update(book);
        await _db.SaveChangesAsync();

        return book;
    }

    public async Task<Book> DeleteBook(int id)
    {
        var book = await GetBook(id);
        _db.Books.Remove(book);
        await _db.SaveChangesAsync();
        
        return book;
    }
}