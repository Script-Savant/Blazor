namespace IMS.UseCases.Interfaces;

public interface IInventoryService
{
    Task<IEnumerable<CoreBusiness.Inventory>> GetInventoriesByNameAsync(string name);
}