﻿using System.Text.RegularExpressions;

namespace Marsol.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class MarsolRecipient
    {
        private static readonly string MOBILE_PHONE_REGEX_STRING = @"^09[1|2|3|4|5][0-9]{7}$";
        private static readonly Regex MOBILE_PHONE_REGEX = new Regex(MOBILE_PHONE_REGEX_STRING);
        /// <summary>
        /// 
        /// </summary>
        public string PhoneNumber { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="phoneNumber"></param>
        public MarsolRecipient(string phoneNumber)
        {
            this.PhoneNumber = phoneNumber;
        }

        public MarsolRecipient()
        {
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsValid { get => !string.IsNullOrWhiteSpace(this.PhoneNumber) && MOBILE_PHONE_REGEX.IsMatch(this.PhoneNumber); }

        override public string ToString()
        {
            return this.PhoneNumber;
        }

    }
}
