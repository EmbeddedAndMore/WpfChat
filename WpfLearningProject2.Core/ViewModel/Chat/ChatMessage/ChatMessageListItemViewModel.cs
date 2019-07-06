using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfLearningProject2.Core
{
    public class ChatMessageListItemViewModel : BaseViewModel
    {
        public string SenderName{ get; set; }
        public string Message { get; set; }
        public string Initials { get; set; }
        public string ProfilePictureRGB { get; set; }
        public bool IsSelected { get; set; }
        public bool SentByMe { get; set; }
        public bool MessagRead => MessageReadTime > DateTimeOffset.MinValue;
        public DateTimeOffset MessageReadTime { get; set; }
        public DateTimeOffset MessageSentTime { get; set; }
    }
}
