using Marsol.Models;
using System;
using System.Collections.Generic;

namespace Marsol.Exceptions
{
    /// <summary>
    /// خطأ في رقم أو أكثر من المستلمين
    /// </summary>
    public class MarsolInvalidRecipientsException : MarsolException
    {
        /// <summary>
        /// خطأ في رقم أو أكثر من المستلمين
        /// </summary>
        public MarsolInvalidRecipientsException(List<MarsolRecipient> invalidRecipients) : base("خطأ في أرقام المستلمين")
        {
            this.InvalidRecipients = invalidRecipients;
        }
        public List<MarsolRecipient> InvalidRecipients { get; private set; }
    }
}
