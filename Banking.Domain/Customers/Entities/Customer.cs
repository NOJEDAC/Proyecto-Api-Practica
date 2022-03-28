using Banking.Domain.Accounts.Entities;
using Common;
using System.Collections.Generic;
using System.Linq;

namespace Banking.Domain.Customers.Entities
{
    public class Customer : Entity
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string IdentityDocument { get; set; }
        public virtual bool Active { get; set; }
        private readonly IList<Account> _accounts;
        public virtual IReadOnlyCollection<Account> Accounts => _accounts.ToList();

        public Customer()
        {
            _accounts = new List<Account>();
        }

        public Customer(long id)
        {
            Id = id;
            _accounts = new List<Account>();
        }

        public virtual string FullName
        {
            get
            {
                return string.Format("{0} {1}", FirstName, LastName);
            }
        }
    }
}
