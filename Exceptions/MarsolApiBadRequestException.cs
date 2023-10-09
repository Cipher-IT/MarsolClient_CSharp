namespace Marsol.Exceptions
{
    /// <summary>
    /// خطأ يتم إرجاعه عند وجود خطأ في البيانات المرسلة إليها
    /// </summary>
    public class MarsolApiBadRequestException : MarsolApiException
    {
        /// <summary>
        /// خطأ يتم إرجاعه عند وجود خطأ في البيانات المرسلة إليها
        /// </summary>
        public MarsolApiBadRequestException(string message) : base(message)
        {

        }
    }
}
