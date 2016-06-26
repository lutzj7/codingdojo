using System.Collections.Generic;

namespace ShoppingCartService
{
    public class ShoppingCartPersistency : IShoppingCartPersistency
    {
        private Dictionary<long, ShoppingCart> _shoppingCarts = new Dictionary<long, ShoppingCart>();
        private long _lastShoppingCardId = 10000;
        
        public ShoppingCart GetShoppingCartById(long id)
        {
            return _shoppingCarts[id];
        }

        public ShoppingCart CreateNewShoppingCart()
        {
            long id = ++_lastShoppingCardId;
            var shoppingCart = new ShoppingCart(id);
            _shoppingCarts.Add(id, shoppingCart);
            return shoppingCart;

        }
    }
}