namespace Marsol.Models.OTP
{
    public class ApiResendOTPRequest
    {
        public Guid RequestId { get; set; }
        public string ResendToken { get; set; }
        public string Operation { get; set; } = "CODE";
    }

    public class ApiResendOTPResponse
    {
        public Guid RequestId { get; set; }
        public string ResendToken { get; set; }
        public int RemainingRetries { get; set; }
    }
}
