using Flurl.Http;
using Marsol.DTOs;
using Marsol.DTOs.OTP;
using Marsol.Exceptions;
using Marsol.Models;
using Marsol.Models.OTP;
using Marsol.Models.OTP.Enums;
using Marsol.Utils;
using Newtonsoft.Json.Linq;

namespace Marsol
{
    /// <summary>
    /// خدمة مرسول لإرسال الرسائل القصيرة داخل ليبيا
    /// </summary>
    public partial class MarsolClient
    {
        private readonly string PublicBaseUrl = "public";
        private readonly MarsolEnvironments Environment = MarsolEnvironments.PRODUCTION;
        private readonly Dictionary<MarsolEnvironments, Uri> ApiBaseUrls = new Dictionary<MarsolEnvironments, Uri> {
            {MarsolEnvironments.PRODUCTION, new Uri("https://api.marsol.ly/")}
        };

        private Uri ApiBaseUrl { get => ApiBaseUrls[Environment]; }

        public string Token { get; set; } = null;
        public MarsolClient(string token, MarsolEnvironments environment = MarsolEnvironments.PRODUCTION)
        {
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
            TokenNotEmpty();
            request.Validate();
            try
            {
                return await new Uri(ApiBaseUrl, $"{PublicBaseUrl}/sms/send").WithHeader("x-auth-token", Token).PostJsonAsync(
                    new MarsolApiSendSmsRequest
                    {
                        message = request.Message.Text,
                        phoneNumbers = request.Recipients.Select(p => p.PhoneNumber),
                        SenderId = request.SenderId
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
        /// <param name="senderId">رقم جهاز المرسل</param>
        /// <returns></returns>
        /// <exception cref="MarsolException"></exception>
        /// <exception cref="MarsolApiServerException"></exception>
        /// <exception cref="MarsolApiNotFoundException"></exception>
        /// <exception cref="MarsolApiUnAuthorizedException"></exception>
        /// <exception cref="MarsolApiBadRequestException"></exception>
        public Task<SendSmsResponse> SendSMSAsync(string message, List<string> phoneNumbers, Guid? senderId = null)
        {
            var request = new MarsolSmsRequest(message, phoneNumbers, senderId);
            return SendSMSAsync(request);
        }

        /// <summary>
        /// إرسال رسالة نصية قصيرة لمجموعة مستلمين بإستخدام رقم سجل
        /// </summary>
        /// <param name="message">محتوى الرسالة النصية</param>
        /// <param name="phonebookId">رقم السحل</param>
        /// <param name="senderId">رقم مرسل خاص إن وجد</param>
        /// <returns></returns>
        public async Task<SendSmsResponse> SendPhonebookSms(string message, Guid phonebookId, Guid? senderId = null)
        {
            TokenNotEmpty();
            var request = new MarsolPhonebookSmsRequest(message, phonebookId, senderId);
            request.Validate();
            try
            {
                return await new Uri(ApiBaseUrl, $"{PublicBaseUrl}/sms/send-phonebook").WithHeader("x-auth-token", Token).PostJsonAsync(request).ReceiveJson<SendSmsResponse>();
            }
            catch (FlurlHttpException ex)
            {
                throw ex.ToMarsolException();
            }
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
            TokenNotEmpty();
            try
            {
                return await new Uri(ApiBaseUrl, $"{PublicBaseUrl}/subscription").WithHeader("x-auth-token", Token).GetJsonAsync<MarsolSubscriptionInfoResponse>();
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
            TokenNotEmpty();
            try
            {
                return await new Uri(ApiBaseUrl, $"{PublicBaseUrl}/requests/{requestId}").WithHeader("x-auth-token", Token).GetJsonAsync<MarsolRequestInfoResponse>();
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
                throw new MarsolException($"رقم طلب غير صالح");
            return GetRequestInfoAsync(_requestId);
        }

        /// <summary>
        /// إرجاع قائمة أجهزة المرسل الخاصة
        /// في حال حجز رقم مرسل خاص او رقم مميز, يمكن إختيار هذا الجهاز عند الإرسال
        /// </summary>
        /// <returns>قائمة أجهزة المرسل الخاصة</returns>
        public async Task<List<MarsolPrivateDevice>> GetPrivateDevicesAsync()
        {
            TokenNotEmpty();
            try
            {
                return await new Uri(ApiBaseUrl, $"{PublicBaseUrl}/devices").WithHeader("x-auth-token", Token).GetJsonAsync<List<MarsolPrivateDevice>>();
            }
            catch (FlurlHttpException ex)
            {
                throw ex.ToMarsolException();
            }
        }

        /// <summary>
        /// الحصول على سجلات الأرقام المحفوظة
        /// </summary>
        /// <returns></returns>
        public async Task<List<MarsolPhonebook>> GetPhoneBooksAsync()
        {
            TokenNotEmpty();
            try
            {
                return await new Uri(ApiBaseUrl, $"{PublicBaseUrl}/phonebooks").WithHeader("x-auth-token", Token).GetJsonAsync<List<MarsolPhonebook>>();
            }
            catch (FlurlHttpException ex)
            {
                throw ex.ToMarsolException();
            }
        }

        /// <summary>
        /// إدخال جهة إتصال جديدة للسجل للإستخدام في الإرسال لاحقا
        /// </summary>
        /// <param name="PhoneBookId">رقم السجل المراد الإدخال اليه</param>
        /// <param name="phoneNumber">رقم الهاتف</param>
        /// <param name="name">إسم لجهة الإتصال</param>
        /// <returns></returns>
        public async Task InsertContactAsync(Guid PhoneBookId, string phoneNumber, string name = null)
        {
            TokenNotEmpty();
            try
            {
                await new Uri(ApiBaseUrl, $"{PublicBaseUrl}/phonebooks/{PhoneBookId}/contacts").WithHeader("x-auth-token", Token).PostJsonAsync(new InsertContactRequest { PhoneNumber = phoneNumber, Name = name });
            }
            catch (FlurlHttpException ex)
            {
                throw ex.ToMarsolException();
            }
        }

        /// <summary>
        /// بداية عملية تأكيد رقم الهاتف
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<InitiateOTPResponse> InitiateOTP(MarsolInitiateOTPRequest request)
        {
            TokenNotEmpty();
            try
            {
                return await new Uri(ApiBaseUrl, $"{PublicBaseUrl}/otp/initiate").WithHeader("x-auth-token", Token).PostJsonAsync(InitiateOTPRequest.FromModel(request)).ReceiveJson<InitiateOTPResponse>();
            }
            catch (FlurlHttpException ex)
            {
                throw ex.ToMarsolException();
            }
        }

        /// <summary>
        /// بداية عملية تأكيد رقم الهاتف
        /// </summary>
        /// <param name="phoneNumber">رقم الهاتف المراد تأكيده</param>
        /// <param name="length">طول كود التأكيد (4 أو 6)</param>
        /// <param name="expiration">صلاحية عملية التأكيد</param>
        /// <param name="language">لغة رسالة التأكيد</param>
        /// <param name="clientOS">نظام التشغيل للمستلم</param>
        /// <returns></returns>
        /// <exception cref="MarsolException"></exception>
        public async Task<InitiateOTPResponse> InitiateOTP(
            string phoneNumber, 
            MarsolOTPLength length = MarsolOTPLength.FOUR,
            OtpExpiration expiration = OtpExpiration.TWO_MIN,
            OTPLanguageEnum language = OTPLanguageEnum.AR,
            ClientOSEnum clientOS = ClientOSEnum.OTHER)
        {
            var recepient = new MarsolRecipient(phoneNumber);
            if(!recepient.IsValid)
                throw new MarsolException($"رقم الهاتف غير صالح");
            return await InitiateOTP(new MarsolInitiateOTPRequest { 
                PhoneNumber = recepient,
                Length = length,
                Expiration = expiration,
                Language = language,
                ClientOs = clientOS
            });
        }

        /// <summary>
        /// إعادة إرسال رمز التأكيد
        /// </summary>
        /// <param name="otpRequestId"></param>
        /// <param name="resendToken"></param>
        /// <returns></returns>
        public async Task<ResendOTPResponse> ResendOTP(Guid otpRequestId, string resendToken)
        {
            TokenNotEmpty();
            try
            {
                return await new Uri(ApiBaseUrl, $"{PublicBaseUrl}/otp/resend").WithHeader("x-auth-token", Token).PostJsonAsync(new ResendOTPRequest { RequestId = otpRequestId, ResendToken = resendToken }).ReceiveJson<ResendOTPResponse>();
            }
            catch (FlurlHttpException ex)
            {
                throw ex.ToMarsolException();
            }
        }

        /// <summary>
        /// التحقق من رمز التأكيد
        /// </summary>
        /// <param name="request"> بيانات الطلب</param>
        /// <returns></returns>
        public async Task<VerifyOTPResponse> VerifyOTPResponse(VerifyOTPRequest request)
        {
            TokenNotEmpty();
            try
            {
                return await new Uri(ApiBaseUrl, $"{PublicBaseUrl}/otp/verify").WithHeader("x-auth-token", Token).PostJsonAsync(request).ReceiveJson<VerifyOTPResponse>();
            }
            catch (FlurlHttpException ex)
            {
                throw ex.ToMarsolException();
            }
        }

        /// <summary>
        /// التحقق من رمز التأكيد
        /// </summary>
        /// <param name="otpRequestId">رقم طلب التأكيد</param>
        /// <param name="code">كود التأكيد</param>
        /// <returns></returns>
        public async Task<VerifyOTPResponse> VerifyOTPResponse(Guid otpRequestId, string code)
        {
            return await VerifyOTPResponse(new VerifyOTPRequest { RequestId = otpRequestId, Code = code });
        }

        /// <summary>
        /// التأكد من حالة الخدمة
        /// </summary>
        /// <returns></returns>
        public async Task<MarsolServiceHealthResponse> GetServiceHealthAsync()
        {
            try
            {
                return await new Uri(ApiBaseUrl, "health").GetJsonAsync<MarsolServiceHealthResponse>();
            }
            catch (FlurlHttpException ex)
            {
                throw ex.ToMarsolException();
            }
        }

        private void TokenNotEmpty()
        {
            if (string.IsNullOrWhiteSpace(Token))
                throw new MarsolEmptyTokenException("token فارغ");
        }
    }

    public enum MarsolEnvironments
    {
        PRODUCTION
    }
}
