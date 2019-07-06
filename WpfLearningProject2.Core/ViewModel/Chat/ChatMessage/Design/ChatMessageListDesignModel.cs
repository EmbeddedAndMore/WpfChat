using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLearningProject2.Core.ViewModel;

namespace WpfLearningProject2.Core
{
    public class ChatMessageListDesignModel : ChatMessageListViewModel
    {
        public static ChatMessageListDesignModel Instance => new ChatMessageListDesignModel();


        public ChatMessageListDesignModel()
        {
            Items = new List<ChatMessageListItemViewModel> {
                new ChatMessageListItemViewModel
                {
                    Initials = "ML",
                    Message = "This is a test message response for design time",
                    SenderName  = "Mahya",
                    ProfilePictureRGB = "3099c5",
                    MessageSentTime = DateTimeOffset.UtcNow,
                    SentByMe = false
                },
                new ChatMessageListItemViewModel
                {
                    Initials = "MA",
                    Message = "This is a test message response for design time",
                    SenderName  = "Mahya",
                    ProfilePictureRGB = "3099c5",
                    MessageSentTime = DateTimeOffset.UtcNow,
                    MessageReadTime = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(1.3)),
                    SentByMe = true
                },
                new ChatMessageListItemViewModel
                {
                    Initials = "ML",
                    Message = "This is a test message response for design time",
                    SenderName  = "Mahya",
                    ProfilePictureRGB = "3099c5",
                    MessageSentTime = DateTimeOffset.UtcNow,
                    SentByMe = false
                },
            };
        }
    }
}
