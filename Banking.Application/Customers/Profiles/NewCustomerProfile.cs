using Banking.Domain.Accounts.Entities;
using Banking.Domain.Customers.Entities;
using AutoMapper;
using Banking.Application.Customers.Dtos;

namespace Banking.Application.Customers.Profiles
{
    public class NewCustomerProfile : Profile
    {
        public NewCustomerProfile()
        {
            CreateMap<NewCustomerDto, Customer>()
               .ReverseMap();
        }
    }
}
