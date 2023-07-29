using System;
using System.Collections.Generic;

namespace Marsol.Models
{
    public class MarsolRequestInfoResponse
    {
        public string RequestId { get; set; }
        public string Message { get; set; }
        public List<MarsolRecipientStatus> Recipients { get; set; }
        public int Parts { get; set; }
        public DateTime Timestamp { get; set; }
        public string Token { get; set; }
    }
}
