namespace ShoppingCartService
{
    public class LineItem
    {
        public LineItem(Product product, int count)
        {
            Product = product;
            Count = count;
            SumCt = product.PriceCt* count;
        }

        public Product Product { get; private set; }
        public int Count { get; private set; }

        public long SumCt { get; private set; }

    }
}