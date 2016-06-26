namespace ShoppingCartService
{
    public class LineItemTO
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public int Count { get; set; }
        public int SinglePrice { get; set; }
        public long TotalPrice { get; set; }
    }
}