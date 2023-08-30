namespace ProductCatalog.WebApp.Core.Responses.Account
{
    public class AuthenticationResponse
    {
        public string Token { get; set; }
        public Guid AccountId { get; set; }
        public bool IsAdmin { get; set; }
        public IEnumerable<ClaimResponse> Claims { get; set; }
    }
}
