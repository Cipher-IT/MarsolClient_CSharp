namespace Marsol.DTOs
{
    internal class MarsolApiSendSmsToPhoneBookRequest
    {
        public string Message { get; set; }
        public Guid PhonebookId { get; set; }
        public Guid? SenderId { get; set; }
    }
}
