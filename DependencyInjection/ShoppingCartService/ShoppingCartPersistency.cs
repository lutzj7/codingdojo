using System.Collections.Generic;

namespace ShoppingCartService
{
    public class ShoppingCartPersistency
    {
        private Dictionary<long, ShoppingCart> _shoppingCarts = new Dictionary<long, ShoppingCart>();
        private long _lastShoppingCardId = 10000;

        private ShoppingCartPersistency()
        {
        }

        private static ShoppingCartPersistency _instance;

        public static ShoppingCartPersistency Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ShoppingCartPersistency();
                }
                return _instance;
            }
        }

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