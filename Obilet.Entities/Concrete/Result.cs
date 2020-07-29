using Newtonsoft.Json;

namespace Obilet.Entities.Concrete.Session
{
    public class Result

    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("data")]
        public object Data { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("user-message")]
        public string UserMessage { get; set; }

        [JsonProperty("api-request-id")]
        public string ApiRequestId { get; set; }

        [JsonProperty("controller")]
        public string Controller { get; set; }

        [JsonProperty("client-request-id")]
        public string ClientRequestId { get; set; }

    }

}
