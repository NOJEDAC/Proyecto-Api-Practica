using Banking.Application.Auth.Dtos;

namespace Banking.Application.Auth.Contracts
{
    public interface IAuthApplicationService
    {
        LoginResponseDto Login(LoginDto loginDto);
    }
}
