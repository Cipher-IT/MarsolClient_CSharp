﻿namespace Marsol.DTOs
{
    internal class MarsolApiSendSmsRequest
    {
        public string Message { get; set; }
        public IEnumerable<string> PhoneNumbers { get; set; }
        public Guid? SenderId { get; set; }
    }
}
