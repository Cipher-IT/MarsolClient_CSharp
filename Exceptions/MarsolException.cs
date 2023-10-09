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
    /// خطأ في إحدا المدخلات
    /// </summary>
    public class MarsolBadRequestException : MarsolException
    {
        /// <summary>
        /// خطأ في إحدا المدخلات
        /// </summary>
        public MarsolBadRequestException(string message) : base(message)
        {

        }
        /// <summary>
        /// خطأ في إحدا المدخلات
        /// </summary>
        public MarsolBadRequestException()
        {

        }
    }
}
