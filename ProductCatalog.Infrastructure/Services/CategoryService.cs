using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using ProductCatalog.Core.Repositories;
using ProductCatalog.Core.Services;
using ProductCatalog.Core.Responses.Category;
using ProductCatalog.Core.Requests.Category;
using ProductCatalog.Core.Helpers;
using ProductCatalog.Core.Entities;

namespace ProductCatalog.Infrastructure.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryResponse> GetCategory(GetCategoryRequest request)
        {
            var category = await _categoryRepository.FindByIdAsync(request.CategoryId);
            if (category is null)
            {
                throw new AppException($"Category with id={request.CategoryId} not found");
            }

            var response = new CategoryResponse(category);

            return response;
        }

        public async Task<List<CategoryResponse>> GetCategoryList(CategoryListRequest request)
        {
            var response = (await _categoryRepository.GetCategoriesAsync(request.Name))
                .Select(x => new CategoryResponse(x))
                .ToList();

            return response;
        }

        public async Task<CategoryResponse> CreateCategory(CreateCategoryRequest request)
        {
            var category = new Category()
            {
                Name = request.Name,
            };

            await _categoryRepository.AddAsync(category);

            await _categoryRepository.SaveChangesAsync();

            var response = new CategoryResponse(category);

            return response;
        }

        public async Task<CategoryResponse> UpdateCategory(Guid categoryId, UpdateCategoryRequest request)
        {
            var category = await _categoryRepository.FindByIdAsync(categoryId);
            if (category is null)
            {
                throw new AppException($"Category with id={categoryId} not found");
            }

            category.Name = request.Name;

            await _categoryRepository.UpdateAsync(category);

            await _categoryRepository.SaveChangesAsync();

            var response = new CategoryResponse(category);

            return response;
        }

        public async Task<CategoryResponse> DeleteCategory(DeleteCategoryRequest request)
        {
            var category = await _categoryRepository.FindByIdAsync(request.CategoryId);
            if (category is null)
            {
                throw new AppException($"Category with id={request.CategoryId} not found");
            }

            await _categoryRepository.RemoveAsync(category);

            await _categoryRepository.SaveChangesAsync();

            var response = new CategoryResponse(category);

            return response;
        }
    }
}
