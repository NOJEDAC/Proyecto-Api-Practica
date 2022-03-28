using AutoMapper;
using Banking.Application.Customers.Dtos;
using Banking.Domain.Customers.Entities;
using System;

namespace Banking.Application.Customers.Assemblers
{
    public class NewCustomerAssembler
    {
        private readonly IMapper _mapper;

        public NewCustomerAssembler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Customer ToEntity(NewCustomerDto newAccountDto)
        {
            Customer account = _mapper.Map<Customer>(newAccountDto);
            DateTime utcNow = DateTime.UtcNow;
            account.CreatedAt = utcNow;
            account.UpdatedAt = utcNow;
            return account;
        }
    }
}
