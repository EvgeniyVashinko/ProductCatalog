using Microsoft.EntityFrameworkCore;
using ProductCatalog.Core.Entities;
using ProductCatalog.Core.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalog.Repository.Repositories
{
    public sealed class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(AppContext context) : base(context) { }

        public async Task AddAccountAsync(Account account, params string[] roleNames)
        {
            if (account is null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            var roles = await Context.Set<Role>().Where(x => roleNames.Contains(x.Name)).ToListAsync();
            account.Roles = roles;

            await DbSet.AddAsync(account);
        }

        public Task<Account> FindByEmailAsync(string email)
        {
            return DbSet.Include(x => x.Roles)
                        .FirstOrDefaultAsync(x => x.Email.ToUpper() == email.ToUpper());
        }

        public Task<Account> FindByIdAsync(Guid id)
        {
            return DbSet.Include(x => x.Roles)
                        .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
