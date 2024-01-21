namespace Marsol.Models
{
    public class SendSmsResponse
    {
        /// <summary>
        /// رقم الطلب المرسل, يمكن استخدامه للتحقق من حالة الطلب
        /// </summary>
        public string RequestId { get; set; }
        /// <summary>
        /// عدد الأرقام التي تم قبولها
        /// </summary>
        public int Accepted { get; set; } = 0;
        /// <summary>
        /// الأرقام التي تم رفضها
        /// </summary>
        public List<string> Rejected { get; set; } = new List<string>();
        /// <summary>
        /// الأرقام المكررة و عدد التكرار
        /// </summary>
        public List<DuplicatedPhoneNumber> Duplicates { get; set; } = new List<DuplicatedPhoneNumber>();

    }
    public class DuplicatedPhoneNumber
    {
        public string Number { get; set; }
        public int Repeats { get; set; }
    }
}
