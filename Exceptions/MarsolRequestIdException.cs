using System;

namespace Marsol.Exceptions
{
    public class MarsolRequestIdException : MarsolException
    {
        public string InvalidId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="invalidId"> رقم الطلب المرفوض</param>
        public MarsolRequestIdException(string invalidId) : base("رمز الطلب غير صحيح")
        {
            this.InvalidId = invalidId;
        }
    }
}
