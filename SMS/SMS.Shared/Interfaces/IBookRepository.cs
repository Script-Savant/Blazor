using SMS.Shared.Models;

namespace SMS.Shared.Interfaces;

public interface IBookRepository
{
    Task<List<Book>> GetBooks();
    Task<Book> GetBook(int id);
    Task<Book> AddBook(Book book);
    Task<Book> UpdateBook(int id, Book book);
    Task<Book> DeleteBook(int id);
}