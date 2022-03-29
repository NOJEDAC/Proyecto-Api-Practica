using Banking.Domain.Auth.Entities;
using FluentNHibernate.Mapping;

namespace Banking.Infrastructure.Accounts.Persistence.NHibernate.Mapping
{
    public class UserGroupMap : ClassMap<UserGroup>
    {
        public UserGroupMap()
        {
            Id(x => x.Id).Column("user_group_id");
            Map(x => x.Active).CustomType<bool>().Column("active");
            Map(x => x.CreatedAt).Column("created_at_utc");
            Map(x => x.UpdatedAt).Column("updated_at_utc");
            References(x => x.User);
            References(x => x.Group);
        }
    }
}
