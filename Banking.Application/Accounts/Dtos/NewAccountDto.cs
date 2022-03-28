using System;

namespace Banking.Application.Accounts.Dtos
{
    public class NewAccountDto
    {
        public string Number { get; set; }
        public decimal Balance { get; set; }
        public bool Locked { get; set; }
        public long CustomerId { get; set; }
        public long Id { get; set; }

        public NewAccountDto()
        {
            Locked = false;
        }
    }
}
