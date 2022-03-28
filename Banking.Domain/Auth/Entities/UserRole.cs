using Common;

namespace Banking.Domain.Auth.Entities
{
    public class UserRole : Entity
    {
        public virtual User User { get; protected set; }
        public virtual Role Role { get; protected set; }
        public virtual bool Active { get; set; }

        public UserRole()
        {
        }
    }
}
