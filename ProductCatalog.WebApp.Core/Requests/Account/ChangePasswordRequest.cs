﻿using System;

namespace ProductCatalog.WebApp.Core.Requests.Account
{
    public class ChangePasswordRequest
    {
        public Guid Id { get; set; }
        public string Password { get; set; }
    }
}
