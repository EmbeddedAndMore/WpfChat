using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfLearningProject2.Core.ViewModel
{
    public class ChatListViewModel : BaseViewModel
    {
        public List<ChatListItemViewModel> Items { get; set; }
    }
}
