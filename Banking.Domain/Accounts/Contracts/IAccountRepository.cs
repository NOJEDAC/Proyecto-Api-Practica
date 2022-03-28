using Banking.Domain.Accounts.Entities;
using Common;

namespace Banking.Domain.Accounts.Contracts
{
    public interface IAccountRepository : IRepository<Account>
    {
        Account GetByNumber(string accountNumber);
        Account GetByNumberWithUpgradeLock(string accountNumber);
    }
}
