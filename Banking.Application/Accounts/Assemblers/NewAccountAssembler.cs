using AutoMapper;
using Banking.Application.Accounts.Dtos;
using Banking.Domain.Accounts.Entities;
using System;

namespace Banking.Application.Accounts.Assemblers
{
    public class NewAccountAssembler
    {
        private readonly IMapper _mapper;

        public NewAccountAssembler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Account ToEntity(NewAccountDto newAccountDto)
        {
            Account account = _mapper.Map<Account>(newAccountDto);
            DateTime utcNow = DateTime.UtcNow;
            account.CreatedAt = utcNow;
            account.UpdatedAt = utcNow;
            return account;
        }
    }
}
