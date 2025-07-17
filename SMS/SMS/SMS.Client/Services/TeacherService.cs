using System.Net.Http.Json;
using SMS.Shared.Interfaces;
using SMS.Shared.Models;

namespace SMS.Client.Services;

public class TeacherService : ITeacherRepository
{
    private readonly  HttpClient _http;

    public TeacherService(HttpClient http)
    {
        _http = http;
    }
    public async Task<List<Teacher>> GetAllTeachers()
    {
        var response = await _http.GetAsync("api/teachers");
        if (!response.IsSuccessStatusCode)
            throw new Exception($"GetAllTeachers failed: {response.StatusCode}");

        var teachers = await response.Content.ReadFromJsonAsync<List<Teacher>>();
        return teachers ?? new List<Teacher>();
    }

    public async Task<Teacher> GetTeacherById(int id)
    {
        var result = await _http.GetAsync($"api/teachers/{id}");
        if (!result.IsSuccessStatusCode)
            throw new Exception($"GetTeacherById failed: {result.StatusCode}");

        var response = await result.Content.ReadFromJsonAsync<Teacher>();
        return response ?? throw new Exception("GetTeacherById returned null.");
    }

    public async Task<Teacher> AddTeacher(Teacher teacher)
    {
        var result = await _http.PostAsJsonAsync("api/teachers", teacher);
        if (!result.IsSuccessStatusCode)
            throw new Exception($"AddTeacher failed: {result.StatusCode}");

        var response = await result.Content.ReadFromJsonAsync<Teacher>();
        return response ?? throw new Exception("AddTeacher returned null.");
    }

    public async Task<Teacher> UpdateTeacher(int id, Teacher teacher)
    {
        var result = await _http.PutAsJsonAsync($"api/teachers/{id}", teacher);
        if (!result.IsSuccessStatusCode)
            throw new Exception($"UpdateTeacher failed: {result.StatusCode}");

        var response = await result.Content.ReadFromJsonAsync<Teacher>();
        return response ?? throw new Exception("UpdateTeacher returned null.");
    }

    public async Task<Teacher> DeleteTeacher(int id)
    {
        var result = await _http.DeleteAsync($"api/teachers/{id}");
        if (!result.IsSuccessStatusCode)
            throw new Exception($"DeleteTeacher failed: {result.StatusCode}");

        var response = await result.Content.ReadFromJsonAsync<Teacher>();
        return response ?? throw new Exception("DeleteTeacher returned null.");
    }
}