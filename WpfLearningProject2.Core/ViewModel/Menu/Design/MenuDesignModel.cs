using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLearningProject2.Core.ViewModel;

namespace WpfLearningProject2.Core
{
    public class MenuDesignModel : MenuViewModel
    {

        public static MenuDesignModel Instance => new MenuDesignModel();

        public MenuDesignModel()
        {
            Items = new List<MenuItemViewModel>()
            {
                new MenuItemViewModel(){Text  = "Design Time Header...", Type = MenuItemType.Header},
                new MenuItemViewModel(){Text  = "Menu Item 1", Icon = IconType.File},
                new MenuItemViewModel(){Text  = "Menu Item 2", Icon = IconType.Picture},
            };
        }
    }
}
