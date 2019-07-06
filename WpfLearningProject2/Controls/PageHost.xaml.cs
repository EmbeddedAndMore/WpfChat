using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfLearningProject2.Core;
using WpfLearningProject2.Core.ViewModel;

namespace WpfLearningProject2
{
    /// <summary>
    /// Interaction logic for PageHost.xaml
    /// </summary>
    public partial class PageHost : UserControl
    {


        public BasePage CurrentPage
        {
            get { return (BasePage)GetValue(CurrentPageProperty); }
            set { SetValue(CurrentPageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentPage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentPageProperty =
            DependencyProperty.Register(nameof(CurrentPage), typeof(BasePage), typeof(PageHost), new UIPropertyMetadata(CurrentPagePropertyChanged));

        
        #region CTOR

        public PageHost()
        {
            InitializeComponent();

            if(DesignerProperties.GetIsInDesignMode(this))
            {
                NewPage.Content = (BasePage)new ApplicationPageValueConverter().Convert(IoC.Get<ApplicationViewModel>().CurrentPage);
            }
        }

        #endregion

        private static void CurrentPagePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var newPageFrame = (d as PageHost).NewPage;
            var oldPageFrame = (d as PageHost).OldPage;


            var oldPageContent = newPageFrame.Content;

            newPageFrame.Content = null;

            oldPageFrame.Content = oldPageContent;

            if (oldPageContent is BasePage oldPage)
            {
                oldPage.ShouldAnimateOut = true;

                Task.Delay((int)(oldPage.SlideSeconds * 100)).ContinueWith(x =>
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        oldPageFrame.Content = null;
                    });
                });
            }


            newPageFrame.Content = e.NewValue;
        }



    }
}
