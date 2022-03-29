using Banking.Domain.Auth.Entities;
using FluentNHibernate.Mapping;

namespace Banking.Infrastructure.Accounts.Persistence.NHibernate.Mapping
{
    public class CustomerUserMap : ClassMap<CustomerUser>
    {
        public CustomerUserMap()
        {
            Id(x => x.Id).Column("customer_user_id");
            Map(x => x.Active).CustomType<bool>().Column("active");
            Map(x => x.CreatedAt).Column("created_at_utc");
            Map(x => x.UpdatedAt).Column("updated_at_utc");
            References(x => x.Customer);
            References(x => x.User);
        }
    }
}
