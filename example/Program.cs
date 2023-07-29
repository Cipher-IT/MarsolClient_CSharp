using Marsol;
namespace MarsolExample
{
    internal class Program
    {
        private const string Token = "You_Token_Here";
        static void Main(string[] args)
        {
            var client = new MarsolClient(Token);
            var status = client.GetServiceHealthAsync().GetAwaiter().GetResult();
            Console.WriteLine($"Service status: {status.Status}");
            var response = client.SendSMSAsync("مرحبا في خدمة مرسول", "0911111111").GetAwaiter().GetResult();
            Console.WriteLine($"Request ID: {response.RequestId}");
            var requestInfo = client.GetRequestInfoAsync(response.RequestId).Result;
            Console.WriteLine($"Request status: {string.Join("\n",requestInfo.Recipients.Select(r=>$"{r.PhoneNumber} -> {r.Status}"))}");
            var subscriptionInfo = client.GetSubscriptionInfoAsync().GetAwaiter().GetResult();
            Console.WriteLine($"Subscription used Quota: {subscriptionInfo.UsedQuota}");
            Console.WriteLine($"Subscription used RemainingQuota: {subscriptionInfo.RemainingQuota}");
        }
    }
}