using Marsol.Models.OTP;
using System;
using System.Collections.Generic;
using System.Text;

namespace Marsol.DTOs.OTP
{
    internal class ApiVerityOtpResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }

        public VerifyOTPResponse ToModel()
        {
            var model = new VerifyOTPResponse { 
                Message = Message,
                Status = VerifyOTPResponseStatus.UNKNOWN
            };
            if(Enum.TryParse(Status, out VerifyOTPResponseStatus status))
            {
                model.Status = status;
            }

            return model;
        }
    }
}
