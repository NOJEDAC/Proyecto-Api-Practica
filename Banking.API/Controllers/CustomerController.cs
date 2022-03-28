using Banking.Application.Customers.Contracts;
using Banking.Application.Customers.ViewModels;
using Banking.Application.Customers.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Common;
using System;
using System.Collections.Generic;

namespace Banking.API.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("v1/customers")]
    [ApiController]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerQueries _customerQueries;
        private readonly ICustomerApplicationService _customerApplicationService;

        public CustomerController(ICustomerQueries customerQueries, ICustomerApplicationService customerApplicationService)
        {
            _customerQueries = customerQueries;
            _customerApplicationService = customerApplicationService;
        }

        [HttpGet]
        public IActionResult GetListPaginated([FromQuery]int page = 0, [FromQuery] int pageSize = 10, [FromQuery] string column = "first_name", [FromQuery] string value = "")
        {
            try
            {                
                List<CustomerDto> customers = _customerQueries.GetListPaginated(page, pageSize, column, value);
                return StatusCode(StatusCodes.Status200OK, customers);
            }
            catch (Exception ex)
            {
                //TODO: Log exception async, for now write exception in the console
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiStringResponse(ApiConstants.InternalServerError));
            }
        }
        [HttpGet("{customerId}")]
        public IActionResult GetUserById(long customerId)
        {
            CustomerDto customer = _customerApplicationService.GetById(customerId);
            return StatusCode(StatusCodes.Status200OK, customer);
        }
        [HttpPost]
        [HttpPut]
        public IActionResult Register([FromBody] NewCustomerDto newAccountDto)
        { 
            NewCustomerResponseDto response = _customerApplicationService.Register(newAccountDto);
            return StatusCode(response.HttpStatusCode, response.Response);
        }
         
        [HttpDelete("{customerId}")] 
        public IActionResult Delete(long customerId)
        {
            NewCustomerResponseDto response = _customerApplicationService.Delete(customerId);
            return StatusCode(response.HttpStatusCode, response.Response);
        }


    }
}
