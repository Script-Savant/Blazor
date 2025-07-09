using SMS.Shared.Models;

namespace SMS.Shared.Interfaces;

public interface IParentRepository
{
    Task<List<Parent>> GetAllParentsAsync();
    Task<Parent> GetParentByIdAsync(int id);
    Task<Parent> AddParentAsync(Parent parent);
    Task<Parent> UpdateParentAsync(int id, Parent parent);
    Task<Parent> DeleteParentAsync(int id);
}