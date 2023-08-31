using System;

namespace ProductCatalog.Core.Requests.Product
{
    public class UpdateProductRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public string SpecialNote { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
    }
}
