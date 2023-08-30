using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ProductCatalog.Repository
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
