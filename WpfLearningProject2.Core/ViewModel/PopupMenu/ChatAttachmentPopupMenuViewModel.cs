using WpfLearningProject2.Core;
using WpfLearningProject2.Core.ViewModel;
using System.Collections.Generic;

namespace WpfLearningProject2.Core
{
    public class ChatAttachmentPopupMenuViewModel: BasePopupViewModel
    {

        #region Public Properties

       

        #endregion


        #region Contructure

        public ChatAttachmentPopupMenuViewModel()
        {
            Content = new MenuViewModel()
            {
                Items = new List<MenuItemViewModel>()
                {
                    new MenuItemViewModel{Text = "Attach a file ...", Type = MenuItemType.Header},
                    new MenuItemViewModel(){Text  = "From Computer 1", Icon = IconType.File},
                    new MenuItemViewModel(){Text  = "From Pictures 2", Icon = IconType.Picture},
                }
            };
        }

        #endregion
    }
}
