
# Marsol CSharp SDK

This is the official C# client for Marsol Services, the client is opensource and maintained by [Cipher IT].

## How to use:
Install marsol package using Nuget package manager on visual studion, or install it using the package manager console `Install-Package Marsol`

### Checking the service status:
#### Request:
```
using Marsol;
...
var marsolClient = new MarsolClient("Your_Token_Here");
var status = await marsolClient.GetServiceHealthAsync();
```

#### Response:
```
public class MarsolServiceHealthResponse
{
    public string Status { get; set; } // "ok" if service up
}
```

### Get Subscription Information:
```
using Marsol;
...
var marsolClient = new MarsolClient("Your_Token_Here");
var subscription = await marsolClient.GetSubscriptionInfoAsync();
```
#### Response:
```
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
```

### Send SMS:
```
using Marsol;
...
var marsolClient = new MarsolClient("Your_Token_Here");
var requestResponse = await marsolClient.SendSMSAsync("Message_Content_Here","0911111111","0922222222",...);
```

#### Response:
```
public class SendSmsResponse
{
    public string RequestId { get; set; }
    public List<string> Accepted { get; set; } = new List<string>(); // list of accepted phone numbers
    public List<string> Rejected { get; set; } = new List<string>(); // list of rejected phone numbers
    public List<DuplicatedPhoneNumber> Duplicates { get; set; } = new List<DuplicatedPhoneNumber>(); // list of duplicated phone numbers with count of duplications
}
```

### SMS Request Status:
```
using Marsol;
...
var marsolClient = new MarsolClient("Your_Token_Here");
var requestInfo = await marsolClient.GetRequestInfoAsync("");
```

#### Response:
```
public class MarsolRequestInfoResponse
    {
        public string RequestId { get; set; }
        public string Message { get; set; } // message content
        public List<MarsolRecipientStatus> Recipients { get; set; } // List of recipients with status
        public int Parts { get; set; } // number of SMS counts for each recipients
        public DateTime Timestamp { get; set; } // timestamp when sending started
        public string Token { get; set; }
    }
```

# API
if you prefere to use the rest api directly, you can check our service swagger of [Marsol Swagger].

[Cipher IT]:<cipher.ly>
[Marsol Swagger]:<https://marsol-demo.tests.ly/api/swagger>