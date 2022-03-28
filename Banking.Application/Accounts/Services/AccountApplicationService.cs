using Banking.Application.Accounts.Assemblers;
using Banking.Application.Accounts.Constants;
using Banking.Application.Accounts.Contracts;
using Banking.Application.Accounts.Dtos;
using Banking.Domain.Accounts.Contracts;
using Banking.Domain.Accounts.Entities;
using Microsoft.AspNetCore.Http;
using Common;
using System;

namespace Banking.Application.Accounts.Services
{
    public class AccountApplicationService : IAccountApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccountRepository _accountRepository;
        private readonly NewAccountAssembler _newAccountAssembler;

        public AccountApplicationService(
            IUnitOfWork unitOfWork,
            IAccountRepository accountRepository,
            NewAccountAssembler newAccountAssembler)
        {
            _unitOfWork = unitOfWork;
            _accountRepository = accountRepository;
            _newAccountAssembler = newAccountAssembler;
        }

        public NewAccountResponseDto Register(NewAccountDto newAccountDto)
        {
            try
            {
                Account account = _newAccountAssembler.ToEntity(newAccountDto);
                _accountRepository.SaveOrUpdate(account);
                return new NewAccountResponseDto
                {
                    HttpStatusCode = StatusCodes.Status201Created,
                    Response = new ApiStringResponse(CustomerAppConstants.AccountCreated)
                };
            }
            catch(Exception ex)
            {
                //TODO: Log exception async, for now write exception in the console
                Console.WriteLine(ex.Message);
                return new NewAccountResponseDto
                {
                    HttpStatusCode = StatusCodes.Status500InternalServerError,
                    Response = new ApiStringResponse(ApiConstants.InternalServerError)
                };
            }
        }
        public NewAccountResponseDto Delete(long accountId)
        {
            try
            {
                Account account = _accountRepository.Get(accountId);
                _accountRepository.Delete(account);
                return new NewAccountResponseDto
                {
                    HttpStatusCode = StatusCodes.Status200OK,
                    Response = CustomerAppConstants.AccountDeleted
                };
            }
            catch (Exception ex)
            {
                //TODO: Log exception async, for now write exception in the console
                Console.WriteLine(ex.Message);
                return new NewAccountResponseDto
                {
                    HttpStatusCode = StatusCodes.Status500InternalServerError,
                    Response = new ApiStringResponse(ApiConstants.InternalServerError)
                };
            }
        }
    }
}
