using Banking.Domain.Auth.Entities;
using FluentNHibernate.Mapping;

namespace Banking.Infrastructure.Accounts.Persistence.NHibernate.Mapping
{
    public class GroupMap : ClassMap<Group>
    {
        public GroupMap()
        {
            Id(x => x.Id).Column("group_id");
            Map(x => x.Name).Column("group_name");
            Map(x => x.Active).CustomType<bool>().Column("active");
            Map(x => x.CreatedAt).Column("created_at_utc");
            Map(x => x.UpdatedAt).Column("updated_at_utc");
        }
    }
}
