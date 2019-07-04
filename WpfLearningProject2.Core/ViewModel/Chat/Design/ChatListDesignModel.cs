using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLearningProject2.Core.ViewModel;

namespace WpfLearningProject2.Core
{
    public class ChatListDesignModel :ChatListViewModel
    {
        public static ChatListDesignModel Instance => new ChatListDesignModel();


        public ChatListDesignModel()
        {
            Items = new List<ChatListItemViewModel> {
                new ChatListItemViewModel
                {
                    Initials = "ML",
                    Message = "This is a test message response for design time",
                    Name  = "Mahya",
                    ProfilePictureRGB = "3099c5",
                    NewContentAvailable = true
                },
                new ChatListItemViewModel
                {
                    Initials = "LR",
                    Message = "This is a test message response for design time",
                    Name = "Lena",
                    ProfilePictureRGB = "309900",
                    IsSelected = true
                }, new ChatListItemViewModel
                {
                    Initials = "UN",
                    Message = "This is a test message response for design time",
                    Name = "UnKnown",
                    ProfilePictureRGB = "9930c5"
                }, new ChatListItemViewModel
                {
                    Initials = "AF",
                    Message = "This is a test message response for design time",
                    Name = "Asghar",
                    ProfilePictureRGB = "c59930"
                },
                new ChatListItemViewModel
                {
                    Initials = "ML",
                    Message = "This is a test message response for design time",
                    Name  = "Mahya",
                    ProfilePictureRGB = "3099c5"
                },
                new ChatListItemViewModel
                {
                    Initials = "LR",
                    Message = "This is a test message response for design time",
                    Name = "Lena",
                    ProfilePictureRGB = "309900"
                }, new ChatListItemViewModel
                {
                    Initials = "UN",
                    Message = "This is a test message response for design time",
                    Name = "UnKnown",
                    ProfilePictureRGB = "9930c5"
                }, new ChatListItemViewModel
                {
                    Initials = "AF",
                    Message = "This is a test message response for design time",
                    Name = "Asghar",
                    ProfilePictureRGB = "c59930"
                }
            };
        }
    }
}
