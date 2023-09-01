using Microsoft.EntityFrameworkCore;
using ProductCatalog.Core.Entities;
using ProductCatalog.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Repository.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AppContext context) : base(context) { }

        public Task<List<Product>> GetProductsAsync(string category, string name, decimal minPrice, decimal maxPrice)
        {
            return DbSet
                .Include(x => x.Category)
                .Where(x => x.Category.Name.StartsWith(category ?? "") &&
                            x.Name.StartsWith(name ?? "") &&
                            (minPrice == 0 && maxPrice == 0 ||
                            x.Price >= minPrice && x.Price <= maxPrice))
                .ToListAsync();
        }

        public Task<Product> FindByIdAsync(Guid id)
        {
            return DbSet.Include(x => x.Category)
                        .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
