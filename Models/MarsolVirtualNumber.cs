using System;
using System.Collections.Generic;
using System.Text;

namespace Marsol.Models
{
    public class MarsolVirtualNumber
    {
        public Guid DeviceId { get; set; }
        public string PhoneNumber { get; set; }
        public bool Available { get; set; }
    }
}
