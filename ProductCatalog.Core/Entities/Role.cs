using System;
using System.Collections.Generic;

namespace ProductCatalog.Core.Entities
{
    public class Role : Entity<Guid>
    {
        public static string AdminRoleName = "Admin";
        public static string UserRoleName = "User";
        public static string AdvancedUserRoleName = "AdvancedUser";

        public string Name { get; set; }

        public ICollection<Account> Accounts { get; set; }
    }
}
