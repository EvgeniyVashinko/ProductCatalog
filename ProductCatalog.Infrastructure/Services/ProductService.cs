using System.Threading.Tasks;
using System;
using ProductCatalog.Core.Repositories;
using ProductCatalog.Core.Responses.Product;
using System.Collections.Generic;
using ProductCatalog.Core.Requests.Product;
using ProductCatalog.Core.Entities;
using System.Linq;
using ProductCatalog.Core.Helpers;
using ProductCatalog.Core.Services;

namespace ProductCatalog.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductResponse> GetProduct(GetProductRequest request)
        {
            var product = await _productRepository.FindByIdAsync(request.ProductId);
            if (product is null)
            {
                throw new AppException($"Product with id={request.ProductId} not found");
            }

            var response = new ProductResponse(product);

            return response;
        }

        public async Task<List<ProductResponse>> GetProductList(ProductListRequest request)
        {
            var response = (await _productRepository.GetProductsAsync(request.Category, request.Name, request.MinPrice, request.MaxPrice))
                .Select(x => new ProductResponse(x))
                .ToList();

            return response;
        }

        public async Task<ProductResponse> CreateProduct(CreateProductRequest request)
        {
            var product = new Product()
            {
                Name = request.Name,
                Note = request.Note,
                Description = request.Description,
                Price = request.Price,
                SpecialNote = request.SpecialNote,
                CategoryId = request.CategoryId
            };

            await _productRepository.AddAsync(product);

            await _productRepository.SaveChangesAsync();

            var response = new ProductResponse(product);

            return response;
        }

        public async Task<ProductResponse> UpdateProduct(Guid productId, UpdateProductRequest request)
        {
            var product = await _productRepository.FindByIdAsync(productId);
            if (product is null)
            {
                throw new AppException($"Product with id={productId} not found");
            }

            product.Name = request.Name;
            product.Note = request.Note;
            product.Description = request.Description;
            product.Price = request.Price;
            product.SpecialNote = request.SpecialNote;
            product.CategoryId = request.CategoryId;

            await _productRepository.UpdateAsync(product);

            await _productRepository.SaveChangesAsync();

            var response = new ProductResponse(product);

            return response;
        }

        public async Task<ProductResponse> DeleteProduct(DeleteProductRequest request)
        {
            var product = await _productRepository.FindByIdAsync(request.ProductId);
            if (product is null)
            {
                throw new AppException($"Product with id={request.ProductId} not found");
            }

            await _productRepository.RemoveAsync(product);

            await _productRepository.SaveChangesAsync();

            var response = new ProductResponse(product);

            return response;
        }
    }
}
