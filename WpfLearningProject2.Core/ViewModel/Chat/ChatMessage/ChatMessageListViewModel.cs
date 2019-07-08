using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfLearningProject2.Core;

namespace WpfLearningProject2.Core
{
    public class ChatMessageListViewModel : BaseViewModel
    {
        #region Public Properties

        public List<ChatMessageListItemViewModel> Items { get; set; }

        public bool AttachmentMenuVisible { get; set; } = false;


        public bool AnyPopupVisible => AttachmentMenuVisible;

        public ChatAttachmentPopupMenuViewModel AttachmentMenu { get; set; }
        #endregion

        #region Commands
        public ICommand AttachmentButtonCommand { get; set; }

        public ICommand PopupClickawayCommand { get; set; }
        #endregion

        #region Constructor

        public ChatMessageListViewModel()
        {
            AttachmentButtonCommand = new RelayCommand(AttachmentButtons);
            PopupClickawayCommand = new RelayCommand(PopupClickaway);

            AttachmentMenu = new ChatAttachmentPopupMenuViewModel();
        }

        
        #endregion

        #region Command methods
        public void AttachmentButtons()
        {
            AttachmentMenuVisible ^= true;
        }
        private void PopupClickaway()
        {
            AttachmentMenuVisible = false;
        }
        #endregion
    }
}
