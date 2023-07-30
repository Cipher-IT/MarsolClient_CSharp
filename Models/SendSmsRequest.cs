using Marsol.Exceptions;

namespace Marsol.Models
{
    [Obsolete("Use MarsolSmsRequest instead", false)]
    public class SendSmsRequest: MarsolSmsRequest
    {
        public SendSmsRequest(MarsolMessage message, List<MarsolRecipient> recipients): base(message, recipients) { }

        public SendSmsRequest(string message, List<string> phoneNumbers) : base(message, phoneNumbers)
        {
        }

        public SendSmsRequest(): base()
        {
            
        }

    }
}
