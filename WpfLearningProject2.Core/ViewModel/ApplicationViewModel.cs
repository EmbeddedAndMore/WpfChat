using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLearningProject2.Core.DataModels;

namespace WpfLearningProject2.Core.ViewModel
{
    public class ApplicationViewModel:BaseViewModel
    {
        public ApplicationPage CurrentPage { get; private set; } = ApplicationPage.Chat;

        public bool SideMenueIsVisible { get; set; } = true;

        public void GoToPage(ApplicationPage page)
        {
            CurrentPage = page;

            SideMenueIsVisible = page == ApplicationPage.Chat;
        }
    }
}
