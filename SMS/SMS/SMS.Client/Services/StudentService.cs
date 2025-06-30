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
        var newStudent = await _httpClient.PostAsJsonAsync("api/student/add-student", student);
        var response = await newStudent.Content.ReadFromJsonAsync<Student>();

        return response;
    }

    public async Task<Student> UpdateStudentAsync(Student student)
    {
        var newStudent = await _httpClient.PutAsJsonAsync("api/student/update-student", student);
        var response = await newStudent.Content.ReadFromJsonAsync<Student>();

        return response;
    }

    public async Task<Student> DeleteStudentAsync(int studentId)
    {
        var singleStudent = await _httpClient.DeleteAsync($"api/student/single-student/{studentId}");
        var response = await singleStudent.Content.ReadFromJsonAsync<Student>();

        return response;
    }

    public async Task<Student> GetStudentByIdAsync(int studentId)
    {
        var singleStudent = await _httpClient.GetAsync($"api/student/single-student/{studentId}");
        var response = await singleStudent.Content.ReadFromJsonAsync<Student>();

        return response;
    }

    public async Task<List<Student>> GetAllStudentsAsync()
    {
        var allStudents = await _httpClient.GetAsync("api/student/all-students");
        var response = await allStudents.Content.ReadFromJsonAsync<List<Student>>();

        return response;
    }
}