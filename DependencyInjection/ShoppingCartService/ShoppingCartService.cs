using System.Linq;

namespace ShoppingCartService
{
    public class ShoppingCartService
    {
        public void AddToCart(long shoppingCardId, string productId, int count)
        {
            var sc = ShoppingCartPersistency.Instance.GetShoppingCartById(shoppingCardId);
            var p = InventoryPersistency.Instance.GetProductById(productId);
            sc.LineItems.Add(new LineItem(p, count));
        }

        public long CreateCart()
        {
            var sc = ShoppingCartPersistency.Instance.CreateNewShoppingCart();
            return sc.Id;
        }


        public ShoppingCartTO GetShoppingCart(long shoppingCardId)
        {
            var sc = ShoppingCartPersistency.Instance.GetShoppingCartById(shoppingCardId);

            var response = new ShoppingCartTO();

            response.LineItems = sc.LineItems.Select(p => new LineItemTO() {
                ProductId = p.Product.Id,
                ProductName = p.Product.Name,
                Count = p.Count,
                SinglePrice = p.Product.PriceCt,
                TotalPrice = p.SumCt
            }).ToList();

            response.Total = sc.LineItems.Sum(p => p.SumCt);

            return response;
        }
    }

}