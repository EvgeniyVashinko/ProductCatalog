using ProductCatalog.Core.Entities;
using System;
using System.Threading.Tasks;

namespace ProductCatalog.Core.Repositories
{
    public interface IAccountRepository : IRepository<Account>
    {
        Task<Account> FindByEmailAsync(string email);
        Task<Account> FindByIdAsync(Guid id);
        Task AddAccountAsync(Account account, params string[] roleNames);
    }
}
