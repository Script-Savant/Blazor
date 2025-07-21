using System.Net.Http.Json;
using SMS.Shared.Interfaces;
using SMS.Shared.Models;

namespace SMS.Client.Services;

public class BookService : IBookRepository
{
    private readonly HttpClient _http;
    
    public BookService(HttpClient http)
    {
        _http = http;
    }
    public async Task<List<Book>> GetBooks()
    {
        var response = await _http.GetAsync("api/books");
        if (!response.IsSuccessStatusCode)
            throw new Exception($"GetAllbooks failed: {response.StatusCode}");

        var books = await response.Content.ReadFromJsonAsync<List<Book>>();
        return books ?? new List<Book>();
    }

    public async Task<Book> GetBook(int id)
    {
        var result = await _http.GetAsync($"api/books/{id}");
        if (!result.IsSuccessStatusCode)
            throw new Exception($"GetBookById failed: {result.StatusCode}");

        var response = await result.Content.ReadFromJsonAsync<Book>();
        return response ?? throw new Exception("GetBookById returned null.");
    }

    public async Task<Book> AddBook(Book book)
    {
        var result = await _http.PostAsJsonAsync("api/books", book);
        if (!result.IsSuccessStatusCode)
            throw new Exception($"AddBook failed: {result.StatusCode}");

        var response = await result.Content.ReadFromJsonAsync<Book>();
        return response ?? throw new Exception("AddBook returned null.");
    }

    public async Task<Book> UpdateBook(int id, Book book)
    {
        var result = await _http.PutAsJsonAsync($"api/books/{id}", book);
        if (!result.IsSuccessStatusCode)
            throw new Exception($"UpdateBook failed: {result.StatusCode}");

        var response = await result.Content.ReadFromJsonAsync<Book>();
        return response ?? throw new Exception("UpdateBook returned null.");
    }

    public async Task<Book> DeleteBook(int id)
    {
        var result = await _http.DeleteAsync($"api/books/{id}");
        if (!result.IsSuccessStatusCode)
            throw new Exception($"DeleteBook failed: {result.StatusCode}");

        var response = await result.Content.ReadFromJsonAsync<Book>();
        return response ?? throw new Exception("DeleteBook returned null.");
    }
}