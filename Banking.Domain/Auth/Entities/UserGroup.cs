using Common;

namespace Banking.Domain.Auth.Entities
{
    public class UserGroup : Entity
    {
        public virtual User User { get; protected set; }
        public virtual Group Group { get; protected set; }
        public virtual bool Active { get; set; }

        public UserGroup()
        {
        }
    }
}
