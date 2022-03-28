using Newtonsoft.Json;

namespace Common
{
    public class ApiStringResponse
    {
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        public ApiStringResponse(string message)
        {
            Message = message;
        }
    }
}
