using Marsol.Utils;
namespace Marsol.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class MarsolMessage
    {
        /// <summary>
        /// نص الرسالة
        /// </summary>
        public string Text { get; private set; }
        public MarsolMessage(string message)
        {
            Text = message;
        }
        public MarsolMessage()
        {
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(Text))
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        public int Parts { get => !this.IsValid() ? 0 : MarsolSmsUtils.GetPartsCount(this.Text); }

        override public string ToString()
        {
            return this.Text;
        }
    }
}
