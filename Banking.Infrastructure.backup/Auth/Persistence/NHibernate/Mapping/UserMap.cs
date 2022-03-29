using Banking.Domain.Auth.Entities;
using FluentNHibernate.Mapping;

namespace Banking.Infrastructure.Accounts.Persistence.NHibernate.Mapping
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.Id).Column("user_id");
            Map(x => x.FirstName).Column("first_name");
            Map(x => x.LastName).Column("last_name");
            Map(x => x.Gender).Column("gender");
            Map(x => x.Name).Column("user_name");
            Map(x => x.Email).Column("email_address");
            Map(x => x.PasswordHash).Column("password_hash");
            Map(x => x.Active).CustomType<bool>().Column("active");
            Map(x => x.CreatedAt).Column("created_at_utc");
            Map(x => x.UpdatedAt).Column("updated_at_utc");
        }
    }
}
