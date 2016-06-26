namespace ShoppingCartService
{
    public class Product
    {
        public Product(string id, string  name , int priceCt)
        {
            Id = id;
            Name = name;
            PriceCt = priceCt;
        }

        public string Id { get; private set; }

        public string Name { get; private set; }

        public int PriceCt { get; private set; }

    }
}