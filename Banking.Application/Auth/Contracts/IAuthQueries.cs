using Banking.Application.Auth.ViewModels;

namespace Banking.Application.Auth.Contracts
{
    public interface IAuthQueries
    {
        LoginViewModel GetLoginInfo(long userId);
    }
}
