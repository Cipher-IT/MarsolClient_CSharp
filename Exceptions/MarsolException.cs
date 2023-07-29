using System;

namespace Marsol.Exceptions
{
    /// <summary>
    /// خطأ عام
    /// </summary>
    public class MarsolException : Exception
    {
        /// <summary>
        /// خطأ عام
        /// </summary>
        public MarsolException(string message) : base(message)
        {

        }
        /// <summary>
        /// خطأ عام
        /// </summary>
        public MarsolException()
        {

        }
    }
    /// <summary>
    /// خطأ عام من الخادم
    /// </summary>
    public class MarsolApiException: MarsolException
    {
        /// <summary>
        /// خطأ عام من الخادم
        /// </summary>
        public MarsolApiException()
        {
            
        }
        /// <summary>
        /// خطأ عام من الخادم
        /// </summary>
        public MarsolApiException(string message):base(message)
        {
            
        }

    }
    /// <summary>
    /// خطأ ترجعه خدمة ساهل عند عدم العثور على البيانات المطلوبه
    /// </summary>
    public class MarsolApiNotFoundException : MarsolApiException
    {
        /// <summary>
        /// خطأ ترجعه خدمة ساهل عند عدم العثور على البيانات المطلوبه
        /// </summary>
        public MarsolApiNotFoundException(string message) : base(message)
        {

        }
    }
    /// <summary>
    /// خطأ ترجعه خدمة مرسول عند عدم وجود رمز وصول صحيح أو عدم توفر إشتراك صالح
    /// </summary>
    public class MarsolApiUnAuthorizedException : MarsolApiException
    {
        /// <summary>
        /// خطأ ترجعه خدمة مرسول عند عدم وجود رمز وصول صحيح أو عدم توفر إشتراك صالح
        /// </summary>
        public MarsolApiUnAuthorizedException(string message): base(message)
        {

        }
    }
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
