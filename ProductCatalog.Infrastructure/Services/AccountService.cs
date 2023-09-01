using ProductCatalog.Core.Repositories;
using ProductCatalog.Core.Services;
using ProductCatalog.Core.Requests.Account;
using ProductCatalog.Core.Responses.Account;
using System.Threading.Tasks;
using ProductCatalog.Core.Helpers;
using ProductCatalog.Core.Entities;

namespace ProductCatalog.Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private readonly IJwtService _jwtService;
        private readonly IAccountRepository _accountRepository;

        public AccountService(IJwtService jwtService, IAccountRepository accountRepository)
        {
            _jwtService = jwtService;
            _accountRepository = accountRepository;
        }

        public async Task<AccountResponse> Login(LoginRequest request)
        {
            var account = await _accountRepository.FindByEmailAsync(request.Email);

            if (account?.VerifyPassword(request.Password) is true)
            {
                var jwt = await _jwtService.GetJwt(account.GetClaims());

                var response = new AccountResponse(account.GetClaims())
                {
                    Token = jwt,
                    AccountId = account.Id,
                };

                return response;
            }

            return null;
        }

        public async Task CreateUser(RegistrationRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Password))
            {
                throw new AppException("Password is required");
            }

            var user = await _accountRepository.FindByEmailAsync(request.Email);
            if (user is not null)
            {
                throw new AppException($"Email \"{user.Email}\" is already taken");
            }

            var salt = PasswordHelper.GenerateSalt(Account.PasswordSaltLength);
            var account = new Account
            {
                Email = request.Email,
                PasswordSalt = salt,
                Password = PasswordHelper.ComputeHash(request.Password, salt),
            };

            if (request.Roles != null)
            {
                await _accountRepository.AddAccountAsync(account, request.Roles.ToArray());
            }
            else
            {
                await _accountRepository.AddAccountAsync(account, Role.UserRoleName);
            }


            await _accountRepository.SaveChangesAsync();
        }

        public async Task ChangePassword(ChangePasswordRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Password))
            {
                throw new AppException("Password is required");
            }

            var user = await _accountRepository.FindByIdAsync(request.Id);
            if (user is not null)
            {
                throw new AppException($"User with id \"{user.Id}\" is not found");
            }

            var salt = PasswordHelper.GenerateSalt(Account.PasswordSaltLength);
            user.PasswordSalt = salt;
            user.Password = PasswordHelper.ComputeHash(request.Password, salt);

            await _accountRepository.UpdateAsync(user);
            await _accountRepository.SaveChangesAsync();
        }
    }
}
