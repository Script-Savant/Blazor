using System.Net.Http.Json;
using SMS.Shared.Interfaces;
using SMS.Shared.Models;

namespace SMS.Client.Services;

public class BookCategoryService : IBookCategoryRepository
{
    private readonly HttpClient _http;

    public BookCategoryService(HttpClient http)
    {
        _http = http;
    }
    
    public async Task<List<BookCategory>> GetAll()
    {
        var response = await _http.GetAsync("api/book-category");
        if (!response.IsSuccessStatusCode)
            throw new Exception($"GetAll book-category failed: {response.StatusCode}");

        var book = await response.Content.ReadFromJsonAsync<List<BookCategory>>();
        return book ?? new List<BookCategory>();
    }

    public async Task<BookCategory> GetById(int id)
    {
        var result = await _http.GetAsync($"api/book-category/{id}");
        if (!result.IsSuccessStatusCode)
            throw new Exception($"GetBookCategoryById failed: {result.StatusCode}");

        var response = await result.Content.ReadFromJsonAsync<BookCategory>();
        return response ?? throw new Exception("GetBookCategoryById returned null.");
    }

    public async Task<BookCategory> Create(BookCategory bookCategory)
    {
        var result = await _http.PostAsJsonAsync("api/book-category", bookCategory);
        if (!result.IsSuccessStatusCode)
            throw new Exception($"AddBookCategory failed: {result.StatusCode}");

        var response = await result.Content.ReadFromJsonAsync<BookCategory>();
        return response ?? throw new Exception("AddBookCategory returned null.");
    }

    public async Task<BookCategory> Update(int id, BookCategory bookCategory)
    {
        var result = await _http.PutAsJsonAsync($"api/book-category/{id}", bookCategory);
        if (!result.IsSuccessStatusCode)
            throw new Exception($"UpdateBookCategory failed: {result.StatusCode}");

        var response = await result.Content.ReadFromJsonAsync<BookCategory>();
        return response ?? throw new Exception("UpdateBookCategory returned null.");
    }

    public async Task<BookCategory> Delete(int id)
    {
        var result = await _http.DeleteAsync($"api/book-category/{id}");
        if (!result.IsSuccessStatusCode)
            throw new Exception($"DeleteBookCategory failed: {result.StatusCode}");

        var response = await result.Content.ReadFromJsonAsync<BookCategory>();
        return response ?? throw new Exception("DeleteBookCategory returned null.");
    }
}