using Common;

namespace Banking.Domain.Auth.Entities
{
    public class RolePermission : Entity
    {
        public virtual Role Role { get; protected set; }
        public virtual Permission Permission { get; protected set; }
        public virtual bool Active { get; set; }

        public RolePermission()
        {
        }
    }
}
