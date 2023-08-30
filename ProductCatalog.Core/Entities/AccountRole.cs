using System;

namespace ProductCatalog.Core.Entities
{
    public class AccountRole : Entity<Guid>
    {
        public Guid AccountId { get; set; }
        public Guid RoleId { get; set; }
    }
}
