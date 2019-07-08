using WpfLearningProject2.Core;
using WpfLearningProject2.Core.ViewModel;

namespace WpfLearningProject2.Core
{
    public class BasePopupViewModel: BaseViewModel
    { 

        #region Public Properties

        public string BubbleBackground{ get; set; }
        

        public ElementHorizontalAlignment ArrowAlignment { get; set; }


        public BaseViewModel Content { get; set; }
        #endregion


        #region Contructure

        public BasePopupViewModel()
        {
            BubbleBackground = "FFFFFF";

            ArrowAlignment = ElementHorizontalAlignment.Left;
        }

        #endregion
    }
}
