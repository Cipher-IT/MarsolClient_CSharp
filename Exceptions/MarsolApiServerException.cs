using System;

namespace Marsol.Exceptions
{
    /// <summary>
    /// خطأ ترجعه خدمة مرسول عند حصول خطأ غير معروف في الخادم
    /// </summary>
    public class MarsolApiServerException : MarsolApiException
    {
        /// <summary>
        /// خطأ ترجعه خدمة مرسول عند حصول خطأ غير معروف في الخادم
        /// </summary>
        public MarsolApiServerException(string message) : base(message)
        {

        }
    }
}
