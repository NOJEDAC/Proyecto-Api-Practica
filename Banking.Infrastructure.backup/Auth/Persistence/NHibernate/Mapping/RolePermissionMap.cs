using Banking.Domain.Auth.Entities;
using FluentNHibernate.Mapping;

namespace Banking.Infrastructure.Accounts.Persistence.NHibernate.Mapping
{
    public class RolePermissionMap : ClassMap<RolePermission>
    {
        public RolePermissionMap()
        {
            Id(x => x.Id).Column("role_permission_id");
            Map(x => x.Active).CustomType<bool>().Column("active");
            Map(x => x.CreatedAt).Column("created_at_utc");
            Map(x => x.UpdatedAt).Column("updated_at_utc");
            References(x => x.Role);
            References(x => x.Permission);
        }
    }
}
