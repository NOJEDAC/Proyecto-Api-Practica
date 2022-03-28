using Newtonsoft.Json;

namespace Banking.Application.Auth.ViewModels
{
    public class PermissionLoginDto
    {
        [JsonProperty(PropertyName = "id")]
        public long Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        public PermissionLoginDto()
        {
        }
    }
}
