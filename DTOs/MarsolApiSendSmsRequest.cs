namespace Marsol.DTOs
{
    internal class MarsolApiSendSmsRequest
    {
        public string message { get; set; }
        public IEnumerable<string> phoneNumbers { get; set; }
        public Guid? SenderId { get; set; }
    }
}
