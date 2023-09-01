using System;

namespace ProductCatalog.Core.Responses.Category
{
    public class CategoryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public CategoryResponse(Entities.Category category)
        {
            Id = category.Id;
            Name = category.Name;
        }
    }
}
