using Marsol.Models;
using System;

namespace Marsol.Exceptions
{
    /// <summary>
    /// النص المراد إرسالة يحتوي على خطأ
    /// نص فارغ أو حروف غير مقبولة
    /// </summary>
    public class MarsolInvalidMessageExceptions : MarsolException
    {
        public MarsolInvalidMessageExceptions(MarsolMessage message) : base("رسالة غير صحيحة")
        {

        }
    }
}
