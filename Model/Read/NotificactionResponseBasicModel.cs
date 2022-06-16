using Newtonsoft.Json;

namespace Model.Read
{
    public class NotificationResponseBasicModel
    {
        [JsonProperty("isSuccess")]
        public bool IsSuccess { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; } = string.Empty;
    }
}

