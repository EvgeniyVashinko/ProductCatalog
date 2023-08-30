using ProductCatalog.Core.Entities;
using System.Threading.Tasks;

namespace ProductCatalog.Core.Repositories
{
    public interface IRepository<TEntity>
    {
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task RemoveAsync(TEntity entity);

        Task SaveChangesAsync();
    }
}
