using Banking.Domain.Customers.Entities;
using Common;

namespace Banking.Domain.Auth.Entities
{
    public class CustomerUser : Entity
    {
        public virtual Customer Customer { get; protected set; }
        public virtual User User { get; protected set; }
        public virtual bool Active { get; set; }

        public CustomerUser()
        {
        }
    }
}
