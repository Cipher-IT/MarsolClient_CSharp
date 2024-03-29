﻿using Marsol.Models.OTP.Enums;

namespace Marsol.Models.OTP
{
    /// <summary>
    /// طلب تأكيد رمز التحقق المستلم
    /// </summary>
    public class VerifyOTPRequest
    {
        /// <summary>
        /// كود التأكيد المستلم
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// رقم طلب التأكيد المرجع عند بداية طلب التأكيد
        /// </summary>
        public Guid RequestId { get; set; }
        public OTPOperationType Operation { get; set; } = OTPOperationType.CODE;
    }
    /// <summary>
    /// نتيحة عملية التحقق 
    /// </summary>
    public class VerifyOTPResponse
    {
        /// <summary>
        /// نتيجة عملية التحقق من الرمز )نجاح أو فشل(
        /// </summary>
        public VerifyOTPResponseStatus Status { get; set; }
        /// <summary>
        /// رسالة توضح سبب الفشل في حالة فشل العملية
        /// </summary>
        public string Message { get; set; }
        ///// <summary>
        ///// رقم المستلم المراد تأكيده
        ///// </summary>
        //public string Recipient { get; set; }
    }

    public enum VerifyOTPResponseStatus
    {
        SUCCESS,
        FAILED, 
        UNKNOWN
    }
}
