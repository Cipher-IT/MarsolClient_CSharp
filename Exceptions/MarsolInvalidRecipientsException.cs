using Marsol.Models;
using System;
using System.Collections.Generic;

namespace Marsol.Exceptions
{
    public class MarsolInvalidRecipientsException : MarsolException
    {
        public MarsolInvalidRecipientsException(List<MarsolRecipient> invalidRecipients) : base("خطأ في أرقام المستلمين")
        {
            this.InvalidRecipients = invalidRecipients;
        }
        public List<MarsolRecipient> InvalidRecipients { get; private set; }
    }
}
