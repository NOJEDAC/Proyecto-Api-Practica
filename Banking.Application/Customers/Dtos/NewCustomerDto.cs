using System; 
using System.Collections.Generic;

namespace Banking.Application.Customers.Dtos
{
    public class NewCustomerDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityDocument { get; set; }
        public bool Active { get; set; }
        public long Id { get; set; }


        public NewCustomerDto()
        {
            Active = true;
        }
    }
}
