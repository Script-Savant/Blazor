using System.Net.Http.Json;
using SMS.Shared.Models;
using SMS.Shared.StudentRepository;

namespace SMS.Client.Services;

public class StudentService : IStudentRepository
{
    private readonly HttpClient _httpClient;

    public StudentService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Student> AddStudentAsync(Student student)
    {
        if (student.BirthDate.HasValue) student.BirthDate.Value.ToUniversalTime();
        var result = await _httpClient.PostAsJsonAsync("api/student/add-student", student);
        if (!result.IsSuccessStatusCode)
            throw new Exception($"AddStudent failed: {result.StatusCode}");

        var response = await result.Content.ReadFromJsonAsync<Student>();
        return response ?? throw new Exception("AddStudent returned null.");
    }

    public async Task<Student> UpdateStudentAsync(Student student)
    {
        
        var result = await _httpClient.PutAsJsonAsync("api/student/update-student", student);
        if (!result.IsSuccessStatusCode)
            throw new Exception($"UpdateStudent failed: {result.StatusCode}");

        var response = await result.Content.ReadFromJsonAsync<Student>();
        return response ?? throw new Exception("UpdateStudent returned null.");
    }

    public async Task<Student> DeleteStudentAsync(int studentId)
    {
        var result = await _httpClient.DeleteAsync($"api/student/single-student/{studentId}");
        if (!result.IsSuccessStatusCode)
            throw new Exception($"DeleteStudent failed: {result.StatusCode}");

        var response = await result.Content.ReadFromJsonAsync<Student>();
        return response ?? throw new Exception("DeleteStudent returned null.");
    }

    public async Task<Student> GetStudentByIdAsync(int studentId)
    {
        var result = await _httpClient.GetAsync($"api/student/single-student/{studentId}");
        if (!result.IsSuccessStatusCode)
            throw new Exception($"GetStudentById failed: {result.StatusCode}");

        var response = await result.Content.ReadFromJsonAsync<Student>();
        return response ?? throw new Exception("GetStudentById returned null.");
    }

    public async Task<List<Student>> GetAllStudentsAsync()
    {
        var result = await _httpClient.GetAsync("api/student/all-students");
        if (!result.IsSuccessStatusCode)
            throw new Exception($"GetAllStudents failed: {result.StatusCode}");

        var response = await result.Content.ReadFromJsonAsync<List<Student>>();
        return response ?? new List<Student>();
    }
}
