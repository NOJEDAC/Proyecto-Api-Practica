using Newtonsoft.Json;

namespace Banking.Application.Auth.ViewModels
{
    public class CustomerLoginDto
    {
        [JsonProperty(PropertyName = "id")]
        public long Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        public CustomerLoginDto()
        {
        }
    }
}
