using System.Windows.Controls;
using System.Windows;
using System;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using WpfLearningProject2.Core;

namespace WpfLearningProject2
{
    /// <summary>
    /// Base page without viewmodel adding supprt
    /// </summary>
    public class BasePage : Page
    {
        #region Public Properties
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;

        public PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;

        public float SlideSeconds { get; set; } = 0.4f;


        public bool ShouldAnimateOut { get; set; }
        #endregion

        #region COntructors

        public BasePage()
        {

            if (this.PageLoadAnimation != PageAnimation.None)
                this.Visibility = Visibility.Collapsed;

            Loaded += BasePage_Loaded;
        }

        #endregion

        #region Animations

        private async void BasePage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (ShouldAnimateOut)
                await AnimateOut();
            else
                await AnimateIn();
        }

        public async Task AnimateIn()
        {
            if (this.PageLoadAnimation == PageAnimation.None)
                return;

            switch (this.PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeInFromRight:
                    await this.SlideAndFadeInFromRight(this.SlideSeconds);
                    break;
            }
        }

        public async Task AnimateOut()
        {
            if (this.PageUnloadAnimation == PageAnimation.None)
                return;

            switch (this.PageUnloadAnimation)
            {
                case PageAnimation.SlideAndFadeOutToLeft:
                    await this.SlideAndFadeOutToLeft(this.SlideSeconds);
                    break;
            }
        }
        #endregion
    }

    /// <summary>
    /// Base page with viewmodel adding supprt
    /// </summary>
    /// <typeparam name="VM"></typeparam>
    public class BasePage<VM> : BasePage
        where VM : BaseViewModel, new()
    {

        #region Private Member

        private VM _viewModel;

        #endregion

        #region Public properties


        /// <summary>
        /// The ViewModel Associated with this.
        /// </summary>
        public VM ViewModel
        {
            get { return _viewModel; }
            set
            {
                if (_viewModel == value)
                    return;

                _viewModel = value;

                this.DataContext = _viewModel;
            }
        }
        #endregion

        #region Contructor

        public BasePage() : base()
        {
            this.ViewModel = new VM();
        } 
        #endregion
    }
}
