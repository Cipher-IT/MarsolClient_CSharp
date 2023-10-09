using Marsol.Exceptions;

namespace Marsol.Models
{
    public class MarsolPhonebookSmsRequest
    {
        public MarsolPhonebookSmsRequest(MarsolMessage message, Guid phoneBookId, Guid? senderId = null)
        {
            this.Message = message;
            this.PhoneBookId = phoneBookId;
            this.SenderId = senderId;
        }

        public MarsolPhonebookSmsRequest(string message, Guid phoneBookId, Guid? senderId = null)
        {
            this.Message = new MarsolMessage(message);
            this.PhoneBookId = phoneBookId;
            this.SenderId = senderId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="phoneBookId"></param>
        /// <param name="senderId"></param>
        /// <exception cref="MarsolBadRequestException"></exception>
        public MarsolPhonebookSmsRequest(string message, string phoneBookId, string senderId = null)
        {
            if (!Guid.TryParse(phoneBookId, out Guid id))
                throw new MarsolBadRequestException("رقم سجل الهواتف غير صالح");
            this.Message = new MarsolMessage(message);
            this.PhoneBookId = id;
            if (!string.IsNullOrEmpty(senderId) && !Guid.TryParse(senderId, out Guid sender))
                throw new MarsolBadRequestException("رقم المرسل غير صالح");
            this.SenderId = string.IsNullOrEmpty(senderId)?null: sender;
        }

        public MarsolPhonebookSmsRequest()
        {

        }

        public MarsolMessage Message { get; set; }
        public Guid PhoneBookId { get; set; }
        public Guid? SenderId { get; set; } = null;

        public bool IsValid()
        {
            if (Message is null || PhoneBookId == Guid.Empty)
                return false;

            if (!Message.IsValid())
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

            if (PhoneBookId == Guid.Empty)
                throw new MarsolBadRequestException("رقم سجل الهواتف فارغ");
        }


    }
}
