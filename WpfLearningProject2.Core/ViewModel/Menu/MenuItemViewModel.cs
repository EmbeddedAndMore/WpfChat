using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfLearningProject2.Core.ViewModel
{
    public class MenuItemViewModel : BaseViewModel
    {
        public string Text { get; set; }


        public IconType Icon { get; set; }

        public MenuItemType Type { get; set; }
    }
}
