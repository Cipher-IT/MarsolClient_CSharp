namespace Marsol.Exceptions
{
    /// <summary>
    /// خطأ يتم إرجاعه عند حصول خطأ غير معروف في الخادم
    /// </summary>
    public class MarsolApiServerException : MarsolApiException
    {
        /// <summary>
        /// خطأ يتم إرجاعه عند حصول خطأ غير معروف في الخادم
        /// </summary>
        public MarsolApiServerException(string message) : base(message)
        {

        }
    }
}
