using Banking.Application.Customers.Assemblers;
using Banking.Application.Customers.Contracts;
using Banking.Application.Customers.Constants;
using Banking.Application.Customers.ViewModels;
using Banking.Application.Customers.Dtos;
using Banking.Domain.Customers.Contracts;
using Banking.Domain.Customers.Entities;
using Microsoft.AspNetCore.Http;
using Common;
using System;

namespace Banking.Application.Customers.Services
{
    public class CustomerApplicationService : ICustomerApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerRepository _accountRepository;
        private readonly NewCustomerAssembler _newAccountAssembler;

        public CustomerApplicationService(
            IUnitOfWork unitOfWork,
            ICustomerRepository accountRepository,
            NewCustomerAssembler newAccountAssembler)
        {
            _unitOfWork = unitOfWork;
            _accountRepository = accountRepository;
            _newAccountAssembler = newAccountAssembler;
        }

        public NewCustomerResponseDto Register(NewCustomerDto newCustomerDto)
        {
            try
            {
                Customer customer = _newAccountAssembler.ToEntity(newCustomerDto);
                _accountRepository.SaveOrUpdate(customer);
                return new NewCustomerResponseDto
                {
                    HttpStatusCode = StatusCodes.Status201Created,
                    Response = new ApiStringResponse(CustomerAppConstants.CustomerCreated)
                };
            }
            catch (Exception ex)
            {
                //TODO: Log exception async, for now write exception in the console
                Console.WriteLine(ex.Message);
                return new NewCustomerResponseDto
                {
                    HttpStatusCode = StatusCodes.Status500InternalServerError,
                    Response = new ApiStringResponse(ApiConstants.InternalServerError)
                };
            }
        }
        public NewCustomerResponseDto Delete(long customerId)
        {
            try
            {
                Customer customer = _accountRepository.Get(customerId);
                _accountRepository.Delete(customer);
                return new NewCustomerResponseDto
                {
                    HttpStatusCode = StatusCodes.Status200OK,
                    Response = CustomerAppConstants.CustomerDeleted
                };
            }
            catch (Exception ex)
            {
                //TODO: Log exception async, for now write exception in the console
                Console.WriteLine(ex.Message);
                return new NewCustomerResponseDto
                {
                    HttpStatusCode = StatusCodes.Status500InternalServerError,
                    Response = new ApiStringResponse(ApiConstants.InternalServerError)
                };
            }
        }
        public CustomerDto GetById(long customerId)
        {
            try
            {
                Customer customer = _accountRepository.Get(customerId);
                CustomerDto customerDto = new CustomerDto();
                customerDto.id = customer.Id;
                customerDto.firstName = customer.FirstName;
                customerDto.lastName = customer.LastName;
                customerDto.identityDocument = customer.IdentityDocument;
                return customerDto;
            }
            catch (Exception ex)
            {
                //TODO: Log exception async, for now write exception in the console
                Console.WriteLine(ex.Message);
                return new CustomerDto();
            }
        }
    }
}
