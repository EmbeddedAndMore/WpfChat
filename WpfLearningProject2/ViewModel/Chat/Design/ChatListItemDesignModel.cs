using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLearningProject2.ViewModel;

namespace WpfLearningProject2
{
    public class ChatListItemDesignModel : ChatListItemViewModel
    {
        public static ChatListItemDesignModel Instance => new ChatListItemDesignModel();

        public ChatListItemDesignModel()
        {
            Initials = "MA";
            Name = "Mohammad";
            Message = "Hi darling! What are you doing? Hope you are doing well";
            ProfilePictureRGB = "FF00FF";
            NewContentAvailable = true;
        }
    }
}
