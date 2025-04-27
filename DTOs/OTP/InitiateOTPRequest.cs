using Marsol.Models.OTP;
using System.Text.Json.Serialization;

namespace Marsol.DTOs.OTP
{
    internal class InitiateOTPRequest
    {
        public string PhoneNumber { get; set; }
        public int Length { get; set; }
        public int Expiration { get; set; }
        public string ClientOs { get; set; }
        public string Language { get; set; }
        public string Operation { get; set; } = "CODE";
        public string? SenderId { get; set; }
        public bool WithoutResend { get; set; } = false;
        public bool UseTestNumber { get; set; } = true;
        public static InitiateOTPRequest FromModel(MarsolInitiateOTPRequest request)
        {
            return new InitiateOTPRequest
            {
                PhoneNumber = request.PhoneNumber.ToString(),
                Length = ((int)request.Length),
                Expiration = ((int)request.Expiration),
                ClientOs = request.ClientOs.ToString(),
                Language = request.Language.ToString(),
                Operation = request.Operation.ToString(),
                SenderId = request.SenderId,
                WithoutResend = request.WithoutResend,
                UseTestNumber = request.UseTestNumbers
            };
        }
    }
}
