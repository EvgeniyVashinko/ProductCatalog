using ProductCatalog.Core.Requests.Account;
using ProductCatalog.Core.Responses.Account;
using System.Threading.Tasks;

namespace ProductCatalog.Core.Services
{
    public interface IAccountService
    {
        Task<AccountResponse> Login(LoginRequest request);
        Task CreateUser(RegistrationRequest request);
        Task ChangePassword(ChangePasswordRequest request);
    }
}
