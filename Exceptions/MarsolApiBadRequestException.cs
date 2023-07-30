using System;

namespace Marsol.Exceptions
{
    /// <summary>
    /// خطأ ترجعه خدمة مرسول عند وجود خطأ في البيانات المرسلة إليها
    /// </summary>
    public class MarsolApiBadRequestException : MarsolApiException
    {
        /// <summary>
        /// خطأ ترجعه خدمة مرسول عند وجود خطأ في البيانات المرسلة إليها
        /// </summary>
        public MarsolApiBadRequestException(string message) : base(message)
        {

        }
    }
}
