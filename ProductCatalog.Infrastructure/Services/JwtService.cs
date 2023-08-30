using Microsoft.IdentityModel.Tokens;
using ProductCatalog.Core.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Infrastructure.Services
{
    public class JwtService : IJwtService
    {
        public SymmetricSecurityKey SecurityKey { get; init; }
        public string SigningAlgorithm => SecurityAlgorithms.HmacSha256;
        public string Issuer { get; init; } 
        public string Audience { get; init; }

        public JwtService(string securityKey, string issuer, string audience)
        {
            SecurityKey = new(Encoding.UTF8.GetBytes(securityKey));
            Issuer = issuer;
            Audience = audience;
        }

        public async Task<string> GetJwt(IEnumerable<Claim> claims)
        {
            var token = new JwtSecurityToken
            (
                issuer: Issuer,
                audience: Audience,
                expires: DateTime.Now.AddHours(3),
                claims: claims,
                signingCredentials: new SigningCredentials(SecurityKey, SigningAlgorithm)
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
