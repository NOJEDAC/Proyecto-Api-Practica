using Banking.Domain.Customers.Contracts;
using Banking.Domain.Customers.Entities;
using Banking.Infrastructure.NHibernate;

namespace Banking.Infrastructure.Customers.Persistence.NHibernate.Repository
{
    public class CustomerNHibernateRepository : NHibernateRepository<Customer>, ICustomerRepository
    {
        public CustomerNHibernateRepository(UnitOfWorkNHibernate unitOfWork) : base(unitOfWork)
        {
        }
    }
}
