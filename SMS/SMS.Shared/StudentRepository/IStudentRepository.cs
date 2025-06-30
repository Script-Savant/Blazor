using SMS.Shared.Models;

namespace SMS.Shared.StudentRepository;

public interface IStudentRepository
{
    Task<Student> AddStudentAsync(Student student);
    Task<Student> UpdateStudentAsync(Student student);
    Task<Student> DeleteStudentAsync(int studentId);
    Task<Student> GetStudentByIdAsync(int studentId);
    Task<List<Student>> GetAllStudentsAsync();
}