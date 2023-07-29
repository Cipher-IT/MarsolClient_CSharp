using Marsol.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace Marsol.Models
{
    public class SendSmsRequest
    {
        public SendSmsRequest(MarsolMessage message, List<MarsolRecipient> recipients)
        {
            this.Message = message;
            this.Recipients = recipients;
        }

        public SendSmsRequest(string message, List<string> phoneNumbers)
        {
            this.Message = new MarsolMessage(message);
            this.Recipients = phoneNumbers.Select(n => new MarsolRecipient(n)).ToList();
        }

        public MarsolMessage Message { get; set; }
        public List<MarsolRecipient> Recipients { get; set; } = new List<MarsolRecipient>();
        public List<MarsolRecipient> InvalidRecipients { get => this.Recipients.Where(p => !p.IsValid()).ToList(); }

        public bool IsValid()
        {
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
            if (!Message.IsValid())
                throw new MarsolInvalidMessageExceptions(Message);

            if (Recipients.Any(p => !p.IsValid()))
                throw new MarsolInvalidRecipientsException(this.InvalidRecipients);
        }
        

    }
}
