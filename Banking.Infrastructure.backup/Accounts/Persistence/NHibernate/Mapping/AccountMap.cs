using Banking.Domain.Accounts.Entities;
using FluentNHibernate.Mapping;

namespace Banking.Infrastructure.Accounts.Persistence.NHibernate.Mapping
{
    public class AccountMap : ClassMap<Account>
    {
        public AccountMap()
        {
            Id(x => x.Id).Column("account_id");
            Map(x => x.Number).Column("number");
            Map(x => x.Balance).Column("balance");
            Map(x => x.Locked).CustomType<bool>().Column("locked");
            Map(x => x.CreatedAt).Column("created_at_utc");
            Map(x => x.UpdatedAt).Column("updated_at_utc");
            References(x => x.Customer, "customer_id");
        }
    }
}
