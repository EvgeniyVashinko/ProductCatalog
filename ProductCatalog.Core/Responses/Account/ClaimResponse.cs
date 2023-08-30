using System.Security.Claims;

namespace ProductCatalog.Core.Responses.Account
{
    public class ClaimResponse
    {
        public string Type { get; set; }
        public string Value { get; set; }

        public ClaimResponse()
        {
        }

        public ClaimResponse(Claim claim)
        {
            Type = claim.Type;
            Value = claim.Value;
        }
    }
}
