using SMS.Shared.Models;

namespace SMS.Shared.Interfaces;

public interface ISubjectRepository
{
    Task<List<Subject>> GetAllSubjects();
    Task<Subject> GetSubjectById(int id);
    Task<Subject> AddSubject(Subject subject);
    Task<Subject> UpdateSubject(int id, Subject subject);
    Task<Subject> DeleteSubject(int id);
}