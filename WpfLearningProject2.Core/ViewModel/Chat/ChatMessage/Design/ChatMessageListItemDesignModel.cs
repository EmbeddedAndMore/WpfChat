using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLearningProject2.Core.ViewModel;
namespace WpfLearningProject2.Core
{
    public class ChatMessageListItemDesignModel : ChatMessageListItemViewModel
    {
        public static ChatMessageListItemDesignModel Instance => new ChatMessageListItemDesignModel();

        public ChatMessageListItemDesignModel()
        {
            Initials = "MA";
            SenderName = "Mohammad";
            Message = "Hi darling! What are you doing? Hope you are doing well";
            ProfilePictureRGB = "FF00FF";
            SentByMe = true;
            MessageSentTime = DateTimeOffset.UtcNow;
            MessageReadTime = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(1.3));
        }
    }
}
