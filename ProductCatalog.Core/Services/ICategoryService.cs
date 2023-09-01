using ProductCatalog.Core.Requests.Category;
using ProductCatalog.Core.Responses.Category;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductCatalog.Core.Services
{
    public interface ICategoryService
    {
        public Task<List<CategoryResponse>> GetCategoryList(CategoryListRequest request);
        public Task<CategoryResponse> GetCategory(GetCategoryRequest request);
        public Task<CategoryResponse> CreateCategory(CreateCategoryRequest request);
        public Task<CategoryResponse> UpdateCategory(Guid categoryId, UpdateCategoryRequest request);
        public Task<CategoryResponse> DeleteCategory(DeleteCategoryRequest request);
    }
}