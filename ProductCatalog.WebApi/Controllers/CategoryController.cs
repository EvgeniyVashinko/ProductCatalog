using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Core.Requests.Category;
using ProductCatalog.Core.Services;
using System;
using System.Threading.Tasks;

namespace ProductCatalog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin, User, AdvancedUser")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetCategory(Guid categoryId)
        {
            var response = await _categoryService.GetCategory(new()
            {
                CategoryId = categoryId
            });

            return Ok(response);
        }

        [HttpGet("List")]
        public async Task<IActionResult> GetCategoryList([FromQuery] CategoryListRequest request)
        {
            var response = await _categoryService.GetCategoryList(request);

            return Ok(response);
        }

        [HttpPost("update/{categoryId}")]
        public async Task<IActionResult> UpdateCategory(Guid categoryId, UpdateCategoryRequest request)
        {
            var response = await _categoryService.UpdateCategory(categoryId, request);

            return Ok(response);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequest request)
        {
            var response = await _categoryService.CreateCategory(request);

            return Ok(response);
        }

        [HttpDelete("{categoryId}")]
        [Authorize(Roles = "Admin, AdvancedUser")]
        public async Task<IActionResult> DeleteCategory(Guid categoryId)
        {
            var response = await _categoryService.DeleteCategory(new()
            {
                CategoryId = categoryId
            });

            return Ok(response);
        }
    }
}
