using System;

namespace Marsol.Exceptions
{
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
}
