using Newtonsoft.Json;
using System.Collections.Generic;

namespace Banking.Application.Auth.ViewModels
{
    public class LoginViewModel
    {
        [JsonProperty(PropertyName = "userId")]
        public long UserId { get; set; }        

        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "userName")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "emailAddress")]
        public string EmailAddress { get; set; }

        [JsonProperty(PropertyName = "token")]
        public string Token { get; set; }

        [JsonProperty(PropertyName = "customers")]
        public List<CustomerLoginDto> Customers { get; set; }

        [JsonProperty(PropertyName = "roles")]
        public List<RoleLoginDto> Roles { get; set; }

        [JsonProperty(PropertyName = "permissions")]
        public List<PermissionLoginDto> Permissions { get; set; }

        public LoginViewModel()
        {
            UserId = 0;
            FirstName = "";
            LastName = "";
            Name = "";
            EmailAddress = "";
            Token = "";
            Customers = new List<CustomerLoginDto>();
            Roles = new List<RoleLoginDto>();
            Permissions = new List<PermissionLoginDto>();
        }
    }

    public class LoginQueryViewModel
    {
        public long userId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string userName { get; set; }
        public string emailAddress { get; set; }
        public string userFirstName { get; set; }
        public string userLastName { get; set; }
        public long customerId { get; set; }
        public string customerFirstName { get; set; }
        public string customerLastName { get; set; }
        public int roleId { get; set; }
        public string roleName { get; set; }
        public long permissionId { get; set; }
        public string permissionName { get; set; }
    }
}
