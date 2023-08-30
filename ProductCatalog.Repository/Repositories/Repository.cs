using Microsoft.EntityFrameworkCore;
using ProductCatalog.Core.Entities;
using ProductCatalog.Core.Repositories;
using System;
using System.Threading.Tasks;

namespace ProductCatalog.Repository.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity<Guid>
    {
        protected readonly DbContext Context;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(DbContext context) => (Context, DbSet) = (context, context.Set<TEntity>());

        public virtual async Task AddAsync(TEntity entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await DbSet.AddAsync(entity);
        }

        public virtual async Task RemoveAsync(TEntity entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            DbSet.Remove(entity);
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            DbSet.Update(entity);
        }

        public Task SaveChangesAsync() => Context.SaveChangesAsync();
    }
}
