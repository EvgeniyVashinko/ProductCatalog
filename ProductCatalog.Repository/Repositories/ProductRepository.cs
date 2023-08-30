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
            throw new NotImplementedException();
        }
    }
}
