namespace ProductCatalog.Core.Requests.Product
{
    public class ProductListRequest
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
    }
}
