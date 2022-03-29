using Banking.Domain.Auth.Entities;
using Banking.Infrastructure.NHibernate;
using System.Linq;
using Banking.Domain.Auth.Contracts;

namespace Banking.Infrastructure.Accounts.Persistence.NHibernate.Repository
{
    public class UserNHibernateRepository : NHibernateRepository<User>, IUserRepository
    {
        public UserNHibernateRepository(UnitOfWorkNHibernate unitOfWork) : base(unitOfWork)
        {
        }

        public User GetByName(string name)
        {
            return _unitOfWork.GetSession()
                .Query<User>()
                .SingleOrDefault(x => x.Name == name);
        }
    }
}
