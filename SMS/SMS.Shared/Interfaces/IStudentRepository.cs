using SMS.Shared.Models;

namespace SMS.Shared.Interfaces;

public interface IStudentRepository
{
    Task<Student> AddStudentAsync(Student student);
    Task<Student> UpdateStudentAsync(Student student);
    Task<Student> DeleteStudentAsync(int studentId);
    Task<Student> GetStudentByIdAsync(int studentId);
    Task<List<Student>> GetAllStudentsAsync();
}