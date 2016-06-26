using System.Collections.Generic;

namespace ShoppingCartService
{
    public class InventoryPersistency:IInventoryPersistency
    {
        private Dictionary<string, Product> _inventory = new Dictionary<string, Product>();
        public InventoryPersistency()
        {
            _inventory.Add("#123", new Product("#123", "Banana", 34));
            _inventory.Add("#124", new Product("#124", "Apple", 37));
        }

        public Product GetProductById(string id)
        {
            return _inventory[id];
        }
    }
}
