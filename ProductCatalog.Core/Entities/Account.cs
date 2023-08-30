using ProductCatalog.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace ProductCatalog.Core.Entities
{
    public class Account : Entity<Guid>
    {
        public const int PasswordSaltLength = 128;

        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }

        public ICollection<Role> Roles { get; set; }

        public bool VerifyPassword(string password)
        {
            return !string.IsNullOrEmpty(password) &&
                   PasswordHelper.ComputeHash(password, PasswordSalt) == Password;
        }

        public void ChangePassword(string password)
        {
            PasswordSalt = PasswordHelper.GenerateSalt(PasswordSaltLength);
            Password = PasswordHelper.ComputeHash(password, PasswordSalt);
        }

        public IEnumerable<Claim> GetClaims()
        {
            var claims = Roles.Select(x => new Claim(ClaimTypes.Role, x.Name)).ToList();

            claims.Add(new Claim(ClaimTypes.Email, Email));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, Id.ToString()));

            return claims;
        }
    }
}
