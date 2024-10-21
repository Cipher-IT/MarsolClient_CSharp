using Texting;

namespace Marsol.Utils
{
    public static class MarsolSmsUtils
    {
        private static readonly SmsHelpers Utils = new SmsHelpers();
        /// <summary>
        /// عدد أجزاء الرسالة
        /// </summary>
        /// <param name="message">محتوى الرسالة</param>
        /// <returns></returns>
        public static int GetPartsCount(string message)
        {
            return Utils.CountSmsParts(message);
        }

        internal static bool IsGSM(string message)
        {
            return Utils.GetEncoding(message) == SmsEncoding.Gsm7Bit;
        }

        internal static bool IsUnicode(string message)
        {
            return Utils.GetEncoding(message) == SmsEncoding.GsmUnicode;
        }
    }
}
