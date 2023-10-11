namespace Marsol.DTOs.OTP
{
    public class ResendOTPRequest
    {
        public Guid RequestId { get; set; }
        public string ResendToken { get; set; }
        public string Operation { get; set; } = "CODE";
    }

    public class ResendOTPResponse
    {
        public Guid RequestId { get; set; }
        public string ResendToken { get; set; }
        public int RemainingRetries { get; set; }
    }
}
