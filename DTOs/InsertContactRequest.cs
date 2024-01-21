using Marsol.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Marsol.DTOs
{
    public class InsertContactRequest
    {
        public string? Name { get; set; }
        public string PhoneNumber { get; set; }
        public Dictionary<string, string>? MetaData { get; set; }
    }
}
