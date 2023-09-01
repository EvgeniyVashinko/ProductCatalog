using Microsoft.EntityFrameworkCore;
using ProductCatalog.Core.Entities;
using ProductCatalog.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalog.Repository.Repositories
{
    public sealed class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppContext context) : base(context) { }

        public Task<Category> FindByIdAsync(Guid id)
        {
            return DbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Category>> GetCategoriesAsync(string category)
        {
            return await DbSet
                .Where(x => x.Name.StartsWith(category ?? ""))
                .ToListAsync();
        }
    }
}
