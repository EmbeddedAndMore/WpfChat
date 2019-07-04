using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLearningProject2.Core;
using WpfLearningProject2.Core.ViewModel;

namespace WpfLearningProject2
{
    public class ViewModelLocator
    {
        public static ViewModelLocator Instance { get; private set; } = new ViewModelLocator();

        public static ApplicationViewModel ApplicationViewModel => IoC.Get<ApplicationViewModel>();
    }
}
