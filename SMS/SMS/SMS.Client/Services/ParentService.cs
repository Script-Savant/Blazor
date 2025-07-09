using System.Net.Http.Json;
using SMS.Shared.Models;
using SMS.Shared.Interfaces;

namespace SMS.Client.Services;

public class ParentService : IParentRepository
{
    private readonly HttpClient _httpClient;

    public ParentService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Parent>> GetAllParentsAsync()
    {
        var response = await _httpClient.GetAsync("api/parents");
        if (!response.IsSuccessStatusCode)
            throw new Exception($"GetAllParents failed: {response.StatusCode}");

        var parents = await response.Content.ReadFromJsonAsync<List<Parent>>();
        return parents ?? new List<Parent>();
    }

    public async Task<Parent> GetParentByIdAsync(int id)
    {
        var result = await _httpClient.GetAsync($"api/parents/{id}");
        if (!result.IsSuccessStatusCode)
            throw new Exception($"GetParentById failed: {result.StatusCode}");

        var response = await result.Content.ReadFromJsonAsync<Parent>();
        return response ?? throw new Exception("GetParentById returned null.");
    }

    public async Task<Parent> AddParentAsync(Parent parent)
    {
        var result = await _httpClient.PostAsJsonAsync("api/parents", parent);
        if (!result.IsSuccessStatusCode)
            throw new Exception($"AddParent failed: {result.StatusCode}");

        var response = await result.Content.ReadFromJsonAsync<Parent>();
        return response ?? throw new Exception("AddParent returned null.");
    }

    public async Task<Parent> UpdateParentAsync(int id, Parent parent)
    {
        var result = await _httpClient.PutAsJsonAsync($"api/parents/{id}", parent);
        if (!result.IsSuccessStatusCode)
            throw new Exception($"UpdateParent failed: {result.StatusCode}");

        var response = await result.Content.ReadFromJsonAsync<Parent>();
        return response ?? throw new Exception("UpdateParent returned null.");
    }

    public async Task<Parent> DeleteParentAsync(int id)
    {
        var result = await _httpClient.DeleteAsync($"api/parents/{id}");
        if (!result.IsSuccessStatusCode)
            throw new Exception($"DeleteParent failed: {result.StatusCode}");

        var response = await result.Content.ReadFromJsonAsync<Parent>();
        return response ?? throw new Exception("DeleteParent returned null.");
    }
}
