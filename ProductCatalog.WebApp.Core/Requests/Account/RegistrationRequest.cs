using System;

namespace ProductCatalog.WebApp.Core.Requests.Account
{
    public class RegistrationRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
