namespace Marsol.DTOs.OTP
{
    public class ResendOTPRequest
    {
        public Guid RequestId { get; set; }
        public string ResendToken { get; set; }
    }

    public class ResendOTPResponse
    {
        public Guid RequestId { get; set; }
        public string ResendToken { get; set; }
        public int RemainingRetries { get; set; }
    }
}
