using System.Collections.Generic;

namespace ShoppingCartService
{
    public class ShoppingCart
    {
        public ShoppingCart(long id)
        {
            Id = id;
        }

        public long Id { get; private set; }

        public List<LineItem> LineItems { get; private set; } = new List<LineItem>();
    }
}