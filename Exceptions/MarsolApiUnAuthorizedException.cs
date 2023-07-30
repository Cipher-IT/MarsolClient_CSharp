using System;

namespace Marsol.Exceptions
{
    /// <summary>
    /// خطأ ترجعه خدمة مرسول عند عدم وجود رمز وصول صحيح أو عدم توفر إشتراك صالح
    /// </summary>
    public class MarsolApiUnAuthorizedException : MarsolApiException
    {
        /// <summary>
        /// خطأ ترجعه خدمة مرسول عند عدم وجود رمز وصول صحيح أو عدم توفر إشتراك صالح
        /// </summary>
        public MarsolApiUnAuthorizedException(string message) : base(message)
        {

        }
    }
}
