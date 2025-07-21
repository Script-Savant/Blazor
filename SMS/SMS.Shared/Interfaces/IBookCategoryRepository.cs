using SMS.Shared.Models;

namespace SMS.Shared.Interfaces;

public interface IBookCategoryRepository
{
    Task<List<BookCategory>> GetAll();
    Task<BookCategory> GetById(int id);
    Task<BookCategory> Create(BookCategory bookCategory);
    Task<BookCategory> Update(int id, BookCategory bookCategory);
    Task<BookCategory> Delete(int id);
}