using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLearningProject2.Core.ViewModel;

namespace WpfLearningProject2.Core
{
    public class MenuItemDesignModel : MenuItemViewModel
    {
        public static MenuItemDesignModel Instance => new MenuItemDesignModel();

        public MenuItemDesignModel()
        {
            Text = "Hello world";
            Icon = IconType.File;
        }
    }
}
