using SMS.Shared.Models;

namespace SMS.Shared.Interfaces;

public interface ITeacherRepository
{
    Task<List<Teacher>> GetAllTeachers();
    Task<Teacher> GetTeacherById(int id);
    Task<Teacher> AddTeacher(Teacher teacher);
    Task<Teacher> UpdateTeacher(int id, Teacher teacher);
    Task<Teacher> DeleteTeacher(int id);
}