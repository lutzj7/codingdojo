using System.Collections.Generic;

namespace ShoppingCartService
{
    public class InventoryPersistency
    {
        private Dictionary<string, Product> _inventory = new Dictionary<string, Product>();
        private InventoryPersistency()
        {
            _inventory.Add("#123", new Product("#123", "Banana", 34));
            _inventory.Add("#124", new Product("#124", "Apple", 37));
        }

        private static InventoryPersistency _instance;

        public static InventoryPersistency Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new InventoryPersistency();
                }
                return _instance;
            }
        }

        public Product GetProductById(string id)
        {
            return _inventory[id];
        }
    }
}
