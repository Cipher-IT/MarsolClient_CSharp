using System;

namespace Marsol.Models
{
    public class MarsolSubscriptionInfoResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Balance { get; set; }
        public int RemainingQuota { get; set; }
        public int UsedQuota { get; set; }
        public DateTime Timestamp { get; set; }
        public DateTime Expiration { get; set; }
    }
}
