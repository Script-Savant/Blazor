using Microsoft.EntityFrameworkCore;
using SMS.Data;
using SMS.Shared.Interfaces;
using SMS.Shared.Models;

namespace SMS.Services;

public class TeacherRepository : ITeacherRepository
{
    private readonly ApplicationDbContext _db;

    public TeacherRepository(ApplicationDbContext db)
    {
        _db = db;
    }
    
    public async Task<List<Teacher>> GetAllTeachers()
    {
        return await _db.Teachers.OrderBy(t => t.LastName).ToListAsync();
    }

    public async Task<Teacher> GetTeacherById(int id)
    {
        var teacher = await _db.Teachers.FirstOrDefaultAsync(t => t.Id == id);
        if (teacher == null) throw new ArgumentNullException();
        
        return teacher;
    }

    public async Task<Teacher> AddTeacher(Teacher teacher)
    {
        if (teacher == null) throw new ArgumentNullException(nameof(teacher));
        
        _db.Teachers.Add(teacher);
        await _db.SaveChangesAsync();

        return teacher;
    }

    public async Task<Teacher> UpdateTeacher(int id, Teacher teacher)
    {
        if (teacher == null) throw new ArgumentNullException(nameof(teacher));
        
        _db.Teachers.Update(teacher);
        await _db.SaveChangesAsync();

        return teacher;
    }

    public async Task<Teacher> DeleteTeacher(int id)
    {
        var teacher = await GetTeacherById(id);
        
        _db.Teachers.Remove(teacher);
        await _db.SaveChangesAsync();

        return teacher;
    }
}