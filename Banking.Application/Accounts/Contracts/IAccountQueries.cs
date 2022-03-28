using Banking.Application.Accounts.ViewModels;
using System.Collections.Generic;

namespace Banking.Application.Accounts.Contracts
{
    public interface IAccountQueries
    {
        List<AccountDto> GetListPaginated(long customerId, int page = 0, int pageSize = 5);
    }
}
