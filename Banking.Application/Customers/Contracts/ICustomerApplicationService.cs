using Banking.Application.Customers.Dtos;
using Banking.Application.Customers.ViewModels;

namespace Banking.Application.Customers.Contracts
{
    public interface ICustomerApplicationService
    {
        NewCustomerResponseDto Register(NewCustomerDto newAccountDto);
        NewCustomerResponseDto Delete(long customerId);
        CustomerDto GetById(long customerId);
    }
}
