using Microsoft.EntityFrameworkCore;
using SMS.Data;
using SMS.Shared.Models;
using SMS.Shared.StudentRepository;

namespace SMS.Services;

public class StudentRepository : IStudentRepository
{
    private readonly ApplicationDbContext _db;

    public StudentRepository(ApplicationDbContext db)
    {
        _db = db;
    }
    
    public async Task<Student> AddStudentAsync(Student student)
    {
        if (student == null) throw new ArgumentNullException();
        
        var newStudent = _db.Students.Add(student).Entity;
        await _db.SaveChangesAsync();

        return newStudent;
    }

    public async Task<Student> UpdateStudentAsync(Student student)
    {
        if (student == null) throw new ArgumentNullException(nameof(student));
        
        _db.Students.Update(student);
        await _db.SaveChangesAsync();

        return student;
    }

    public async Task<Student> DeleteStudentAsync(int studentId)
    {
        var student = await GetStudentByIdAsync(studentId);

        _db.Students.Remove(student);
        await _db.SaveChangesAsync();

        return student;
    }

    public async Task<Student> GetStudentByIdAsync(int studentId)
    {
        var student = await _db.Students.FirstOrDefaultAsync(s => s.Id == studentId);
        
        if (student == null) throw new ArgumentNullException();

        return student;
    }

    public async Task<List<Student>> GetAllStudentsAsync()
    {
        var students = await _db.Students
            .OrderBy(s => s.Id)
            .ToListAsync();
        
        return students;
    }
}