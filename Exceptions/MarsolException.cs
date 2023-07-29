using System;

namespace Marsol.Exceptions
{
    /// <summary>
    /// خطأ عام
    /// </summary>
    public class MarsolException : Exception
    {
        public MarsolException(string message) : base(message)
        {

        }
        public MarsolException()
        {

        }
    }
    public class MarsolApiException: MarsolException
    {
        public MarsolApiException()
        {
            
        }
        public MarsolApiException(string message):base(message)
        {
            
        }

    }
    /// <summary>
    /// خطأ ترجعه خدمة ساهل عند عدم العثور على البيانات المطلوبه
    /// </summary>
    public class MarsolApiNotFoundException : MarsolApiException
    {
        public MarsolApiNotFoundException(string message) : base(message)
        {

        }
    }
    /// <summary>
    /// خطأ ترجعه خدمة مرسول عند عدم وجود رمز وصول صحيح أو عدم توفر إشتراك صالح
    /// </summary>
    public class MarsolApiUnAuthorizedException : MarsolApiException
    {
        public MarsolApiUnAuthorizedException(string message): base(message)
        {

        }
    }
    /// <summary>
    /// خطأ ترجعه خدمة مرسول عند وجود خطأ في البيانات المرسلة إليها
    /// </summary>
    public class MarsolApiBadRequestException : MarsolApiException
    {
        public MarsolApiBadRequestException(string message) : base(message)
        {

        }
    }

    /// <summary>
    /// خطأ ترجعه خدمة مرسول عند حصول خطأ غير معروف في الخادم
    /// </summary>
    public class MarsolApiServerException : MarsolApiException
    {
        public MarsolApiServerException(string message) : base(message)
        {

        }
    }
}
