using System.Net.Http.Json;
using SMS.Shared.Interfaces;
using SMS.Shared.Models;

namespace SMS.Client.Services;

public class SubjectService :ISubjectRepository
{
    private readonly HttpClient _http;

    public SubjectService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<Subject>> GetAllSubjects()
    {
        var response = await _http.GetAsync("api/subjects");
        if (!response.IsSuccessStatusCode)
            throw new Exception($"GetAllSubjects failed: {response.StatusCode}");

        var subjects = await response.Content.ReadFromJsonAsync<List<Subject>>();
        return subjects ?? new List<Subject>();
    }

    public async Task<Subject> GetSubjectById(int id)
    {
        var result = await _http.GetAsync($"api/subjects/{id}");
        if (!result.IsSuccessStatusCode)
            throw new Exception($"GetSubjectById failed: {result.StatusCode}");

        var response = await result.Content.ReadFromJsonAsync<Subject>();
        return response ?? throw new Exception("GetSubjectById returned null.");
    }

    public async Task<Subject> AddSubject(Subject subject)
    {
        var result = await _http.PostAsJsonAsync("api/subjects", subject);
        if (!result.IsSuccessStatusCode)
            throw new Exception($"AddSubject failed: {result.StatusCode}");

        var response = await result.Content.ReadFromJsonAsync<Subject>();
        return response ?? throw new Exception("AddSubject returned null.");
    }

    public async Task<Subject> UpdateSubject(int id, Subject subject)
    {
        var result = await _http.PutAsJsonAsync($"api/subjects/{id}", subject);
        if (!result.IsSuccessStatusCode)
            throw new Exception($"UpdateSubject failed: {result.StatusCode}");

        var response = await result.Content.ReadFromJsonAsync<Subject>();
        return response ?? throw new Exception("UpdateSubject returned null.");
    }

    public async Task<Subject> DeleteSubject(int id)
    {
        var result = await _http.DeleteAsync($"api/subjects/{id}");
        if (!result.IsSuccessStatusCode)
            throw new Exception($"DeleteSubject failed: {result.StatusCode}");

        var response = await result.Content.ReadFromJsonAsync<Subject>();
        return response ?? throw new Exception("DeleteSubject returned null.");
    }
}