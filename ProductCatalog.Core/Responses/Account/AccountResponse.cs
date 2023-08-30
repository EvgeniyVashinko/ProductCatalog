using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace ProductCatalog.Core.Responses.Account
{
    public class AccountResponse
    {
        public string Token { get; set; }
        public Guid AccountId { get; set; }
        public IEnumerable<ClaimResponse> Claims { get; set; }

        public AccountResponse()
        {
        }

        public AccountResponse(IEnumerable<Claim> claims)
        {
            Claims = claims.Select(x => new ClaimResponse(x));
        }
    }
}
