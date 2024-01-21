using System;
using System.Collections.Generic;
using System.Text;

namespace Marsol.Models
{
    public class MarsolPhonebook
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public string AccountId { get; set; }
        public int ContactsCount { get; set; }
    }
}
