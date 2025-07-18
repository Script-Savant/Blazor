using Microsoft.EntityFrameworkCore;
using SMS.Data;
using SMS.Shared.Interfaces;
using SMS.Shared.Models;

namespace SMS.Services;

public class SubjectRepository : ISubjectRepository
{
    private readonly ApplicationDbContext _db;

    public SubjectRepository(ApplicationDbContext db)
    {
        _db = db;
    }
    
    public async Task<List<Subject>> GetAllSubjects()
    {
        var subjects = await _db.Subjects.ToListAsync();
        return subjects;
    }

    public async Task<Subject> GetSubjectById(int id)
    {
        var subject = await _db.Subjects.FindAsync(id);
        if (subject == null)
        {
            throw new Exception("Subject not found");
        }

        return subject;
    }

    public async Task<Subject> AddSubject(Subject subject)
    {
        subject.CreatedById = "Jane Smith";
        subject.CreatedOn = DateTime.Now;
        if (subject == null)
        {
            throw new Exception("Subject not found");
        }
        
        _db.Subjects.Add(subject);
        await _db.SaveChangesAsync();
        
        return subject;
    }

    public async Task<Subject> UpdateSubject(int id, Subject subject)
    {
        subject.CreatedById = "Jane Smith";
        subject.CreatedOn = DateTime.Now;
        
        if (subject == null)
        {
            throw new Exception("Subject not found");
        }
        
        
        _db.Subjects.Update(subject);
        await _db.SaveChangesAsync();

        return subject;
    }

    public async Task<Subject> DeleteSubject(int id)
    {
        var subject = await GetSubjectById(id);
        _db.Subjects.Remove(subject);
        await _db.SaveChangesAsync();
        
        return subject;
    }
}