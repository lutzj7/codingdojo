using System.Linq;

namespace ShoppingCartService
{
    public class ShoppingCartService
    {
        private IInventoryPersistency _inventoryPersistency;
        private IShoppingCartPersistency _shoppingCartPersistency;

        public ShoppingCartService(IInventoryPersistency inventoryPersistency, IShoppingCartPersistency shoppingCartPersistency)
        {
            _inventoryPersistency = inventoryPersistency;
            _shoppingCartPersistency = shoppingCartPersistency;
        }

        public void AddToCart(long shoppingCardId, string productId, int count)
        {
            var shoppingCart = _shoppingCartPersistency.GetShoppingCartById(shoppingCardId);
            Product product = _inventoryPersistency.GetProductById(productId);

            shoppingCart.LineItems.Add(new LineItem(product, count));
        }

        public long CreateCart()
        {
            var shoppingCart = _shoppingCartPersistency.CreateNewShoppingCart();
            return shoppingCart.Id;
        }


        public ShoppingCartTO GetShoppingCart(long shoppingCardId)
        {
            var shoppingCart = _shoppingCartPersistency.GetShoppingCartById(shoppingCardId);

            var response = new ShoppingCartTO();

            response.LineItems = shoppingCart.LineItems.Select(p => new LineItemTO() {
                ProductId = p.Product.Id,
                ProductName = p.Product.Name,
                Count = p.Count,
                SinglePrice = p.Product.PriceCt,
                TotalPrice = p.SumCt
            }).ToList();

            response.Total = shoppingCart.LineItems.Sum(p => p.SumCt);

            return response;
        }
    }

}