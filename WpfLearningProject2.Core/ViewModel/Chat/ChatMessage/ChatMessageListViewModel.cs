using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfLearningProject2.Core.ViewModel
{
    public class ChatMessageListViewModel : BaseViewModel
    {
        public List<ChatMessageListItemViewModel> Items { get; set; }
    }
}
