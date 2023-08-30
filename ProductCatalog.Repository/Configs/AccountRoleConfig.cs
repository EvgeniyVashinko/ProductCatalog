using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductCatalog.Core.Entities;

namespace ProductCatalog.Repository.Configs
{
    public class AccountRoleConfig : IEntityTypeConfiguration<AccountRole>
    {
        public void Configure(EntityTypeBuilder<AccountRole> builder)
        {
            builder.ToTable(nameof(AccountRole));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("AccountRoleId");
        }
    }
}
