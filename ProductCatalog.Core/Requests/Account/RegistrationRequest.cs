using System;
using System.Collections.Generic;

namespace ProductCatalog.Core.Requests.Account
{
    public class RegistrationRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public List<string> Roles { get; set; }
    }
}
