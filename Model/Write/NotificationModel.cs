using Newtonsoft.Json;

namespace Model.Write
{
    public class NotificationModel
    {
        [JsonProperty("deviceId")]
        public string DeviceId { get; set; } = string.Empty;
        [JsonProperty("isAndroiodDevice")]
        public bool IsAndroiodDevice { get; set; } = true;
        [JsonProperty("title")]
        public string Title { get; set; } = "Transacción Recibida";
        [JsonProperty("body")]
        public string Body { get; set; } = string.Empty;
        [JsonProperty("image")]
        public string Image { get; set; } = string.Empty;
    }

    public class GoogleNotification
    {
        public class DataPayload
        {
            [JsonProperty("title")]
            public string Title { get; set; } = string.Empty;
            [JsonProperty("body")]
            public string Body { get; set; } = string.Empty;
        }

        [JsonProperty("priority")]
        public string Priority { get; set; } = "high";
        [JsonProperty("data")]
        public DataPayload Data { get; set; }
        [JsonProperty("notification")]
        public DataPayload Notification { get; set; }
    }
}