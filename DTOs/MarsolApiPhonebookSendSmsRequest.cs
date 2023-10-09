using System;
using System.Collections.Generic;
using System.Text;

namespace Marsol.DTOs
{
    internal class MarsolApiPhonebookSendSmsRequest
    {
        public string message { get; set; }
        public Guid PhonebookId { get; set; }
        public string? SenderId { get; set; }
    }
}
