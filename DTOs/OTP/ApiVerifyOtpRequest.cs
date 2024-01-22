using Marsol.Models.OTP.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Marsol.DTOs.OTP
{
    internal class ApiVerifyOtpRequest
    {
        public string Code { get; set; }
        public string RequestId { get; set; }
        public string Operation { get; set; }
    }
}
