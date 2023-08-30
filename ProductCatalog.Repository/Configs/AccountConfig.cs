using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductCatalog.Core.Entities;

namespace ProductCatalog.Repository.Configs
{
    public class AccountConfig : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable(nameof(Account));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("AccountId");

            builder.HasMany(x => x.Roles).WithMany(x => x.Accounts)
                .UsingEntity<AccountRole>(
                    right => right.HasOne<Role>().WithMany().HasForeignKey(x => x.RoleId),
                    left => left.HasOne<Account>().WithMany().HasForeignKey(x => x.AccountId),
                    join => join.ToTable("AccountRole"));
        }
    }
}
