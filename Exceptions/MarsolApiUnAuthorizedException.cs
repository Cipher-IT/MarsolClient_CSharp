namespace Marsol.Exceptions
{
    /// <summary>
    /// خطأ يتم إرجاعه عند عدم وجود رمز وصول صحيح أو عدم توفر إشتراك صالح
    /// </summary>
    public class MarsolApiUnAuthorizedException : MarsolApiException
    {
        /// <summary>
        /// خطأ يتم إرجاعه عند عدم وجود رمز وصول صحيح أو عدم توفر إشتراك صالح
        /// </summary>
        public MarsolApiUnAuthorizedException(string message) : base(message)
        {

        }
    }
}
