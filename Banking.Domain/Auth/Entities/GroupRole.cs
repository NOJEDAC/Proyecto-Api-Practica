using Common;

namespace Banking.Domain.Auth.Entities
{
    public class GroupRole : Entity
    {
        public virtual Group Group { get; protected set; }
        public virtual Role Role { get; protected set; }
        public virtual bool Active { get; set; }

        public GroupRole()
        {
        }
    }
}
