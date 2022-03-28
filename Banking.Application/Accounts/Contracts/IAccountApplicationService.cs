using Banking.Application.Accounts.Dtos;

namespace Banking.Application.Accounts.Contracts
{
    public interface IAccountApplicationService
    {
        NewAccountResponseDto Register(NewAccountDto newAccountDto);
        NewAccountResponseDto Delete(long accountId);
    }
}
