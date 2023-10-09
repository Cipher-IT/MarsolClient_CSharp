using Marsol.Exceptions;

namespace Marsol.Models
{
    public class MarsolSmsRequest
    {
        public MarsolSmsRequest(MarsolMessage message, List<MarsolRecipient> recipients, Guid? senderId = null)
        {
            this.Message = message;
            this.Recipients = recipients;
            this.SenderId = senderId;
        }

        public MarsolSmsRequest(string message, List<string> phoneNumbers, Guid? senderId = null)
        {
            this.Message = new MarsolMessage(message);
            this.Recipients = phoneNumbers.Select(n => new MarsolRecipient(n)).ToList();
            this.SenderId = senderId;
        }

        public MarsolSmsRequest()
        {

        }

        public MarsolMessage Message { get; set; }
        public List<MarsolRecipient> Recipients { get; set; } = new List<MarsolRecipient>();
        public Guid? SenderId { get; set; } = null;
        public List<MarsolRecipient> InvalidRecipients { get => this.Recipients?.Where(p => !p.IsValid()).ToList() ?? new List<MarsolRecipient>(); }

        public bool IsValid()
        {
            if (Message is null || Recipients is null || Recipients.Count == 0)
                return false;

            if (!Message.IsValid())
                return false;

            if (InvalidRecipients.Any())
                return false;

            return true;
        }

        /// <summary>
        /// تقوم بالتأكد من صلاحية الطلب قبل الإرسال للخدمة
        /// </summary>
        /// <exception cref="MarsolInvalidMessageExceptions">رسالة خطأ</exception>
        /// <exception cref="MarsolInvalidRecipientsException">خطأ في أحد المستلمين أو أكثر</exception>
        public void Validate()
        {
            if (Message is null || !Message.IsValid())
                throw new MarsolInvalidMessageExceptions(Message);

            if (Recipients.Any(p => !p.IsValid()))
                throw new MarsolInvalidRecipientsException(this.InvalidRecipients);
        }
    }
}
