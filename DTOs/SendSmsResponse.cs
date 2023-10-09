using System;
using System.Collections.Generic;
using System.Text;

namespace Marsol.DTOs
{
    public class SendSmsResponse
    {
        public string RequestId { get; set; }
        public List<string> Accepted { get; set; } = new List<string>();
        public List<string> Rejected { get; set; } = new List<string>();
        public List<DuplicatedPhoneNumber> Duplicates { get; set; } = new List<DuplicatedPhoneNumber>();

    }
    public class DuplicatedPhoneNumber
    {
        public string Number { get; set; }
        public int Repeats { get; set; }
    }
}
