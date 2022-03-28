namespace Banking.Application.Accounts.ViewModels
{
    public class AccountDto
    {
        public long id { get; set; }
        public string number { get; set; }
        public decimal balance { get; set; }
        public bool locked { get; set; }
        public string customerName { get; set; }

        public AccountDto()
        {
        }
    }
}
