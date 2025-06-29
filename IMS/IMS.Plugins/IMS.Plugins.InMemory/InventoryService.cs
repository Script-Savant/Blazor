using IMS.CoreBusiness;
using IMS.UseCases.Interfaces;

namespace IMS.Plugins.InMemory;

public class InventoryService : IInventoryService
{
    private List<Inventory> _inventory;

    public InventoryService()
    {
        _inventory = new List<Inventory>()
        {
            new Inventory{InventoryId = 1, InventoryName = "Bike Seat", Quantity = 10, Price = 5},
            new Inventory{InventoryId = 2, InventoryName = "Bike Body", Quantity = 10, Price = 25},
            new Inventory{InventoryId = 3, InventoryName = "Bike Wheels", Quantity = 20, Price = 10},
            new Inventory{InventoryId = 4, InventoryName = "Bike Pedals", Quantity = 20, Price = 2}
        };
    }
    
    public async Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) return await Task.FromResult(_inventory);

        return _inventory.Where(i => i.InventoryName.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
    }
}