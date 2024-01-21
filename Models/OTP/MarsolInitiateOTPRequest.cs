using Marsol.Models;
using Marsol.Models.OTP.Enums;

namespace Marsol.Models.OTP
{
    public class MarsolInitiateOTPRequest
    {
        public MarsolRecipient PhoneNumber { get; set; }
        public MarsolOTPLength Length { get; set; } = MarsolOTPLength.FOUR;
        public OtpExpiration Expiration { get; set; } = OtpExpiration.FIVE_MIN;
        public ClientOSEnum ClientOs { get; set; } = ClientOSEnum.OTHER;
        public OTPLanguageEnum Language { get; set; } = OTPLanguageEnum.AR;
        public OTPOperationType Operation { get; set; } = OTPOperationType.CODE;
        public string? SenderId { get; set; }
    }
}
