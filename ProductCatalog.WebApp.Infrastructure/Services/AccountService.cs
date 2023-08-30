using ProductCatalog.WebApp.Core.Requests.Account;
using ProductCatalog.WebApp.Core.Responses.Account;
using ProductCatalog.WebApp.Core.Services;
using System.Net;
using System.Text;
using System.Text.Json;

namespace ProductCatalog.WebApp.Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AccountService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<AuthenticationResponse> GetData(AuthenticationRequest request)
        {
            var path = "/api/Account/Login";      

            using (var httpClient = _httpClientFactory.CreateClient("Auth"))
            {
                var json = JsonSerializer.Serialize(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var result = await httpClient.PostAsync(path, content);

                AuthenticationResponse response = null;
                if (result.StatusCode == HttpStatusCode.OK)
                {
                    var str = await result.Content.ReadAsStringAsync();

                    response = JsonSerializer.Deserialize<AuthenticationResponse>(str, new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                }

                return response;
            }
        }

        public async Task<AuthenticationResponse> Registration(RegistrationRequest request)
        {
            var path = "/api/Account/Registration";

            using (var httpClient = _httpClientFactory.CreateClient("Auth"))
            {
                var json = JsonSerializer.Serialize(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var result = await httpClient.PostAsync(path, content);

                var str = await result.Content.ReadAsStringAsync();

                var response = JsonSerializer.Deserialize<AuthenticationResponse>(str, new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

                return response;
            }
        }
    }
}
