using ProductCatalog.WebApp.Core.Requests.Account;
using ProductCatalog.WebApp.Core.Responses.Account;

namespace ProductCatalog.WebApp.Core.Services
{
    public interface IAccountService
    {
        Task<AuthenticationResponse> GetData(AuthenticationRequest request);
        Task<AuthenticationResponse> Registration(RegistrationRequest request);
    }
}
