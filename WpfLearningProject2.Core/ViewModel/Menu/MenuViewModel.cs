using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLearningProject2.Core.ViewModel;

namespace WpfLearningProject2.Core.ViewModel
{
    public class MenuViewModel:BaseViewModel
    {
        public List<MenuItemViewModel> Items { get; set; }
    }
}
