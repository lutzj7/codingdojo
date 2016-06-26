using System.Collections.Generic;

namespace ShoppingCartService.Tests
{
    public class InventoryPersistencyFake:IInventoryPersistency
    {
        private Dictionary<string, Product> _inventory = new Dictionary<string, Product>();
        public InventoryPersistencyFake()
        {
        }

        public Product GetProductById(string id)
        {
            return _inventory[id];
        }

        public bool TryAddProduct(Product product)
        {
            if (product != null)
            {
                _inventory.Add(product.Id, product);
                return true;
            }

            return false;
        }
    }
}
