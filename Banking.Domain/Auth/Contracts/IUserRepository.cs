using Banking.Domain.Auth.Entities;
using Common;

namespace Banking.Domain.Auth.Contracts
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByName(string accountNumber);
    }
}
