namespace Marsol.Models
{
    public class MarsolSubscriptionInfoResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Quota { get; set; }
        public decimal RemainingQuota { get; set; }
        public decimal UsedQuota { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
