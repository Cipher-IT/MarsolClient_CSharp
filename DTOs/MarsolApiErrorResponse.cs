using System;
using System.Collections.Generic;
using System.Text;

namespace Marsol.DTOs
{
    internal abstract class MarsolApiError
    {
        public int StatusCode { get; set; }
        public string Error { get; set; }
        public abstract string GetMessage();
    }
    internal class MarsolApiErrorResponse: MarsolApiError
    {
        public string Message { get; set; }
        public override string GetMessage()
        {
            return this.Message;
        }
    }
    internal class MarsolApiMultiErrorResponse: MarsolApiError
    {
        public List<string> Message { get; set; }
        public override string GetMessage()
        {
            return string.Join("\n", this.Message);
        }
    }
}
