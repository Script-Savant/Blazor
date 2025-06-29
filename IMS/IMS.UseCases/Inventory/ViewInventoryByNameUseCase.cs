using IMS.UseCases.Interfaces;

namespace IMS.UseCases.Inventory;

public class ViewInventoryByNameUseCase
{
    private readonly IInventoryService _inventoryService;

    public ViewInventoryByNameUseCase(IInventoryService inventoryService)
    {
        _inventoryService = inventoryService;
    }
    
    public async Task<IEnumerable<CoreBusiness.Inventory>> ExecuteAsync(string name = "")
    {
        return await _inventoryService.GetInventoriesByNameAsync(name);
    }
}