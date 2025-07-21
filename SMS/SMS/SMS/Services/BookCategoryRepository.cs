using Microsoft.EntityFrameworkCore;
using SMS.Data;
using SMS.Shared.Interfaces;
using SMS.Shared.Models;

namespace SMS.Services;

public class BookCategoryRepository : IBookCategoryRepository
{
    private readonly ApplicationDbContext _db;

    public BookCategoryRepository(ApplicationDbContext db)
    {
        _db = db;
    }
    
    public async Task<List<BookCategory>> GetAll()
    {
        return await _db.BookCategories.ToListAsync();
    }

    public async Task<BookCategory> GetById(int id)
    {
        var category = await _db.BookCategories.FindAsync(id);
        if (category == null)
        {
            throw new Exception($"BookCategory with id {id} not found");
        }
        return category;
    }

    public async Task<BookCategory> Create(BookCategory bookCategory)
    {
        if (bookCategory == null)
        {
            throw new ArgumentNullException(nameof(bookCategory));
        }
        
        _db.BookCategories.Add(bookCategory);
        await _db.SaveChangesAsync();

        return bookCategory;
    }

    public async Task<BookCategory> Update(int id, BookCategory bookCategory)
    {
        if (bookCategory == null)
        {
            throw new ArgumentNullException(nameof(bookCategory));
        }
        
        _db.BookCategories.Update(bookCategory);
        await _db.SaveChangesAsync();

        return bookCategory;
    }

    public async Task<BookCategory> Delete(int id)
    {
        var category = await GetById(id);
        _db.BookCategories.Remove(category);
        await _db.SaveChangesAsync();
        
        return category;
    }
}