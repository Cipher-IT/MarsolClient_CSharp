namespace Marsol.Exceptions
{
    /// <summary>
    /// خطأ يتم إرجاعه عند عدم العثور على البيانات المطلوبه
    /// </summary>
    public class MarsolApiNotFoundException : MarsolApiException
    {
        /// <summary>
        /// خطأ يتم إرجاعه عند عدم العثور على البيانات المطلوبه
        /// </summary>
        public MarsolApiNotFoundException(string message) : base(message)
        {

        }
    }
}
