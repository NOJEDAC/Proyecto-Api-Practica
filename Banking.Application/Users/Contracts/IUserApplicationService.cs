using Banking.Application.Users.Dtos;

namespace Banking.Application.Users.Contracts
{
    public interface IUserApplicationService
    {
        NewUserResponseDto Register(NewUserDto newUserDto);
    }
}
