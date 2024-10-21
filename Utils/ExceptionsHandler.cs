using Flurl.Http;
using Marsol.DTOs;
using Marsol.Exceptions;

namespace Marsol.Utils
{
    internal static class ExceptionsHandler
    {

        public static MarsolException ToMarsolException(this FlurlHttpException exception)
        {
            try
            {
                MarsolApiError response;
                try
                {
                    response = exception.GetResponseJsonAsync<MarsolApiMultiErrorResponse>().GetAwaiter().GetResult();
                }
                catch (FlurlParsingException)
                {
                    try
                    {
                        response = exception.GetResponseJsonAsync<MarsolApiErrorResponse>().GetAwaiter().GetResult();
                    }
                    catch (Exception)
                    {
                        return new MarsolException("خطأ غير معروف" + "\n" + exception.Message);
                    }
                }

                switch (response.StatusCode)
                {
                    case 400:
                        return new MarsolApiBadRequestException(response.GetMessage());
                    case 401:
                        return new MarsolApiUnAuthorizedException(response.GetMessage());
                    case 404:
                        return new MarsolApiNotFoundException(response.GetMessage());
                    case 500:
                        return new MarsolApiServerException(response.GetMessage());
                    default:
                        return new MarsolException(response.GetMessage());
                }
            }
            catch (Exception)
            {
                return new MarsolException("خطأ غير معروف");
            }

        }
    }
}
