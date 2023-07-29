using Marsol.Utils;
namespace Marsol.Models
{
    public class MarsolMessage
    {
        public string Text { get; private set; }
        public MarsolMessage(string message)
        {
            Text = message;
        }

        public bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(Text))
            {
                return false;
            }
            return true;
        }

        public int Parts { get => !this.IsValid() ? 0 : MarsolSmsUtils.GetPartsCount(this.Text); }
    }
}
