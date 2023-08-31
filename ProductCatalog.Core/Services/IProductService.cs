using ProductCatalog.Core.Requests.Product;
using ProductCatalog.Core.Responses.Product;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductCatalog.Core.Services
{
    public interface IProductService
    {
        public Task<List<ProductResponse>> GetProductList(ProductListRequest request);
        public Task<ProductResponse> GetProduct(GetProductRequest request);
        public Task<ProductResponse> CreateProduct(CreateProductRequest request);
        public Task<ProductResponse> UpdateProduct(Guid productId, UpdateProductRequest request);
        public Task<ProductResponse> DeleteProduct(DeleteProductRequest request);
    }
}