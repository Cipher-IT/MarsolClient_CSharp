using Flurl.Http;
using Marsol.DTOs;
using Marsol.Exceptions;
using Marsol.Models;
using Marsol.Utils;

namespace Marsol
{
    /// <summary>
    /// خدمة مرسول لإرسال الرسائل القصيرة داخل ليبيا
    /// </summary>
    public partial class MarsolClient
    {
        private readonly string PublicBaseUrl = "public/";
        private const string SendSMSURL = "send";
        private const string SubscriptionInfoUrl = "subscription-info";
        private const string RequestInfoUrl = "request-info";
        private const string ServicehealthUrl = "health";
        private readonly MarsolEnvironments Environment = MarsolEnvironments.PRODUCTION;
        private readonly Dictionary<MarsolEnvironments, Uri> ApiBaseUrls = new Dictionary<MarsolEnvironments, Uri> {
            {MarsolEnvironments.PRODUCTION, new Uri("https://api.marsol.ly/")}
        };

        private Uri ApiBaseUrl { get => ApiBaseUrls[Environment]; }

        private string Token;

        public MarsolClient(string token, MarsolEnvironments environment = MarsolEnvironments.PRODUCTION)
        {
            if (string.IsNullOrWhiteSpace(token))
                throw new MarsolException("token فارغ");
            Token = token;
            Environment = environment;
        }


        /// <summary>
        /// إرسال رسالة نصية قصيرة لمجموعة مستلمين
        /// </summary>
        /// <param name="request">طلب يحتوي على نص الرسالة و قائمة من أرقام المستلمين</param>
        /// <returns></returns>
        /// <exception cref="MarsolException"></exception>
        /// <exception cref="MarsolApiServerException"></exception>
        /// <exception cref="MarsolApiNotFoundException"></exception>
        /// <exception cref="MarsolApiUnAuthorizedException"></exception>
        /// <exception cref="MarsolApiBadRequestException"></exception>
        public async Task<SendSmsResponse> SendSMSAsync(MarsolSmsRequest request)
        {
            request.Validate();
            try
            {
                return await new Uri(ApiBaseUrl, SendSMSURL).WithHeader("x-auth-token", Token).PostJsonAsync(
                    new MarsolApiSendSmsRequest
                    {
                        message = request.Message.Text,
                        phoneNumbers = request.Recipients.Select(p => p.PhoneNumber)
                    }).ReceiveJson<SendSmsResponse>();
            }
            catch (FlurlHttpException ex)
            {
                throw ex.ToMarsolException();
            }
        }

        /// <summary>
        /// إرسال رسالة نصية قصيرة لمجموعة مستلمين
        /// </summary>
        /// <param name="message">نص الرسالة المراد إرسالها</param>
        /// <param name="phoneNumbers">قائمة الأرقام المراد إرسال الرسالة لهم</param>
        /// <returns></returns>
        /// <exception cref="MarsolException"></exception>
        /// <exception cref="MarsolApiServerException"></exception>
        /// <exception cref="MarsolApiNotFoundException"></exception>
        /// <exception cref="MarsolApiUnAuthorizedException"></exception>
        /// <exception cref="MarsolApiBadRequestException"></exception>
        public Task<SendSmsResponse> SendSMSAsync(string message, params string[] phoneNumbers)
        {
            var request = new MarsolSmsRequest(message, phoneNumbers.ToList());
            return SendSMSAsync(request);
        }

        // <summary>
        /// إرسال رسالة نصية قصيرة لمجموعة مستلمين
        /// </summary>
        /// <param name="message">نص الرسالة المراد إرسالها</param>
        /// <param name="phoneNumbers">قائمة الأرقام المراد إرسال الرسالة لهم</param>
        /// <returns></returns>
        /// <exception cref="MarsolException"></exception>
        /// <exception cref="MarsolApiServerException"></exception>
        /// <exception cref="MarsolApiNotFoundException"></exception>
        /// <exception cref="MarsolApiUnAuthorizedException"></exception>
        /// <exception cref="MarsolApiBadRequestException"></exception>
        public Task<SendSmsResponse> SendSMSAsync(string message, List<string> phoneNumbers)
        {
            var request = new MarsolSmsRequest(message, phoneNumbers);
            return SendSMSAsync(request);
        }

        /// <summary>
        /// الإستفسار عن تفاصيل الإشتراك الحالي و الحصة المتوفرة و المستخدمة
        /// </summary>
        /// <returns></returns>
        /// <exception cref="MarsolException"></exception>
        /// <exception cref="MarsolApiServerException"></exception>
        /// <exception cref="MarsolApiNotFoundException"></exception>
        /// <exception cref="MarsolApiUnAuthorizedException"></exception>
        /// <exception cref="MarsolApiBadRequestException"></exception>
        public async Task<MarsolSubscriptionInfoResponse> GetSubscriptionInfoAsync()
        {
            try
            {
                return await new Uri(ApiBaseUrl, SubscriptionInfoUrl).WithHeader("x-auth-token", Token).GetJsonAsync<MarsolSubscriptionInfoResponse>();
            }
            catch (FlurlHttpException ex)
            {
                throw ex.ToMarsolException();
            }
        }

        /// <summary>
        /// الإستفسار عن حالة طلبات إرسال سابقة
        /// </summary>
        /// <param name="requestId">رقم الطلب المرسل</param>
        /// <returns></returns>
        /// <exception cref="MarsolException"></exception>
        /// <exception cref="MarsolApiServerException"></exception>
        /// <exception cref="MarsolApiNotFoundException"></exception>
        /// <exception cref="MarsolApiUnAuthorizedException"></exception>
        /// <exception cref="MarsolApiBadRequestException"></exception>
        public async Task<MarsolRequestInfoResponse> GetRequestInfoAsync(Guid requestId)
        {
            try
            {
                return await new Uri(ApiBaseUrl, $"{RequestInfoUrl}/{requestId}").WithHeader("x-auth-token", Token).GetJsonAsync<MarsolRequestInfoResponse>();
            }
            catch (FlurlHttpException ex)
            {
                throw ex.ToMarsolException();
            }
        }

        /// <summary>
        /// الإستفسار عن حالة طلبات إرسال سابقة
        /// </summary>
        /// <param name="requestId">رقم الطلب المرسل</param>
        /// <returns></returns>
        /// <exception cref="MarsolException"></exception>
        /// <exception cref="MarsolApiServerException"></exception>
        /// <exception cref="MarsolApiNotFoundException"></exception>
        /// <exception cref="MarsolApiUnAuthorizedException"></exception>
        /// <exception cref="MarsolApiBadRequestException"></exception>
        public Task<MarsolRequestInfoResponse> GetRequestInfoAsync(string requestId)
        {
            if (!Guid.TryParse(requestId, out Guid _requestId))
                throw new MarsolException($"");
            return GetRequestInfoAsync(_requestId);
        }

        public async Task<MarsolServiceHealthResponse> GetServiceHealthAsync()
        {
            try
            {
                return await new Uri(ApiBaseUrl, ServicehealthUrl).GetJsonAsync<MarsolServiceHealthResponse>();
            }
            catch (FlurlHttpException ex)
            {
                throw ex.ToMarsolException();
            }
        }
    }

    public enum MarsolEnvironments
    {
        PRODUCTION
    }
}
