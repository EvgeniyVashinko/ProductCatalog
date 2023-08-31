using System;

namespace ProductCatalog.Core.Responses.Product
{
    public class ProductResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public string SpecialNote { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }

        public ProductResponse(Entities.Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Description = product.Description;
            Note = product.Note;
            SpecialNote = product.SpecialNote;
            Price = product.Price;
            Category = product.Category.Name;
        }
    }
}
