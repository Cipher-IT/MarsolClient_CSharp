using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Marsol.Models
{
    public class MarsolRecipient
    {
        private static readonly string MOBILE_PHONE_REGEX_STRING = @"^09[1|2|4|5][0-9]{6}$";
        private static readonly Regex MOBILE_PHONE_REGEX = new Regex(MOBILE_PHONE_REGEX_STRING);
        public string PhoneNumber { get; private set; }
        public MarsolRecipient(string phoneNumber)
        {
            this.PhoneNumber = phoneNumber;
        }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(this.PhoneNumber) && MOBILE_PHONE_REGEX.IsMatch(this.PhoneNumber);
        }

    }
}
