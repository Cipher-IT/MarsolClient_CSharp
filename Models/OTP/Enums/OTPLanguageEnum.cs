using System;

namespace Marsol.Models.OTP.Enums
{
    /// <summary>
    ///  لغات رمز التأكيد
    /// </summary>
    public enum OTPLanguageEnum
    {
        /// <summary>
        /// إرسال رمز التأكد باللغة العربية
        /// </summary>
        AR,
        /// <summary>
        /// إرسال رمز التأكد باللغة الإنجليزية
        /// </summary>
        EN
    }
    /// <summary>
    /// أنواع عمليات إرسال رمز التأكيد
    /// </summary>
    public enum OTPOperationType
    {
        /// <summary>
        /// إرسال رمز التأكد في رسالة نصية
        /// </summary>
        CODE,
        /// <summary>
        /// إرسال رمز التأكيد في رسالة صوتية
        /// </summary>
        VOICE,
        /// <summary>
        /// إرسال مكالمة صوتية للتأكيد
        /// </summary>
        FLASH_CALL,
    }
}
