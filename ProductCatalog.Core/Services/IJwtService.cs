using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProductCatalog.Core.Services
{
    public interface IJwtService
    {
        SymmetricSecurityKey SecurityKey { get; init; }
        string SigningAlgorithm { get; }
        public string Issuer { get; init; }
        public string Audience { get; init; }
        Task<string> GetJwt(IEnumerable<Claim> claims);
    }
}
