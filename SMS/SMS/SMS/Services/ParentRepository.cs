using Microsoft.EntityFrameworkCore;
using SMS.Data;
using SMS.Shared.Models;
using SMS.Shared.ParentRepository;

namespace SMS.Services;

public class ParentRepository : IParentRepository
{

    private readonly ApplicationDbContext _db;

    public ParentRepository(ApplicationDbContext db)
    {
        _db = db;
    }
    
    public async Task<List<Parent>> GetAllParentsAsync()
    {
        var parents = await _db.Parents
            .Include(p => p.Student)
            .OrderBy(p => p.LastName)
            .ToListAsync();
        
        return parents;
    }

    public async Task<Parent> GetParentByIdAsync(int id)
    {
        var parent = await _db.Parents.FirstOrDefaultAsync(p => p.Id == id);
        if (parent == null) throw new ArgumentNullException();

        return parent;
    }

    public async Task<Parent> AddParentAsync(Parent parent)
    {
        if (parent == null) throw new ArgumentNullException();
        
        var newParent = _db.Parents.Add(parent).Entity;
        await _db.SaveChangesAsync();

        return newParent;
    }

    public async Task<Parent> UpdateParentAsync(int id, Parent parent)
    {
        if (parent == null) throw new ArgumentNullException(nameof(parent));
        
        _db.Parents.Update(parent);
        await _db.SaveChangesAsync();

        return parent;
    }

    public async Task<Parent> DeleteParentAsync(int id)
    {
        var parent = await GetParentByIdAsync(id);

        _db.Parents.Remove(parent);
        await _db.SaveChangesAsync();

        return parent;
    }
}