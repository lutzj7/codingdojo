using System.Collections.Generic;

namespace ShoppingCartService
{
    public class ShoppingCartTO
    {
        public List<LineItemTO> LineItems { get; set; }
        public long Total { get; set; }
    }
}