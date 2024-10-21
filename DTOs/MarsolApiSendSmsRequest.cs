using System.Text.Json.Serialization;

namespace Marsol.DTOs
{
    internal class MarsolApiSendSmsRequest
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("phoneNumbers")]
        public IEnumerable<string> PhoneNumbers { get; set; }
        [JsonPropertyName("senderId")]
        public Guid? SenderId { get; set; }
    }
}
