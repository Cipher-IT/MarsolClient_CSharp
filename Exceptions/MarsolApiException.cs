using System;

namespace Marsol.Exceptions
{
    /// <summary>
    /// خطأ عام من الخادم
    /// </summary>
    public class MarsolApiException : MarsolException
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
        public MarsolApiException(string message) : base(message)
        {

        }

    }
}
