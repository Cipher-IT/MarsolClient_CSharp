using System;
using System.Collections.Generic;
using System.Text;

namespace Marsol.DTOs
{
    internal class MarsolApiSendSmsRequest
    {
        public string message { get; set; }
        public IEnumerable<string> phoneNumbers { get; set; }
    }
}
