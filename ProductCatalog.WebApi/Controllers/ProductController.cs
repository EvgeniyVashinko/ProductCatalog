using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Core.Requests.Product;
using ProductCatalog.Core.Services;
using System;
using System.Threading.Tasks;

namespace ProductCatalog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProduct(Guid productId)
        {
            var response = await _productService.GetProduct(new()
            {
                ProductId = productId
            });

            return Ok(response);
        }

        [HttpGet("List")]
        public async Task<IActionResult> GetProductList([FromQuery] ProductListRequest request)
        {
            var response = await _productService.GetProductList(request);

            return Ok(response);
        }

        [HttpPost("update/{productId}")]
        public async Task<IActionResult> UpdateProduct(Guid productId, UpdateProductRequest request)
        {
            var response = await _productService.UpdateProduct(productId, request);

            return Ok(response);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateProduct(CreateProductRequest request)
        {
            var response = await _productService.CreateProduct(request);

            return Ok(response);
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProduct(Guid productId)
        {
            var response = await _productService.DeleteProduct(new()
            {
                ProductId = productId
            });

            return Ok(response);
        }
    }
}
