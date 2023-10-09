using System;
using System.Collections.Generic;
using System.Text;

namespace Marsol.DTOs.OTP
{
    public class InitiateOTPResponse
    {
        public int Expiration { get; set; }
        public decimal Price { get; set; }
        public Guid RequestId { get; set; }
        public string ResendToken { get; set; }
    }
}
