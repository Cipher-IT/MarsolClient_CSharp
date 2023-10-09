using System;
using System.Collections.Generic;
using System.Text;

namespace Marsol.DTOs
{
    public class MarsolPhonebook
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ContactsCount { get; set; }
    }
}
