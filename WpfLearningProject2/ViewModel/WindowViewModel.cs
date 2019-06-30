

using System.Windows;

namespace WpfLearningProject2.ViewModel
{
    public class WindowViewModel : BaseViewModel
    {
        private Window _window;
        private int _outerMarginSize = 10;
        private int _windowRadious = 10;


        #region Public Memeber

        /// <summary>
        /// The resize boarder thickness
        /// </summary>
        public int ResizeBoarder { get; set; } = 5;

        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBoarder + OuterMarginSize); }}

        public int OuterMarginSize {
            get
            {
                return _window.WindowState == WindowState.Maximized ? 0 : _outerMarginSize;
            }
            set
            {
                _outerMarginSize = value;
            }
        }

        public Thickness OuterMarginSizeThickness{ get { return new Thickness(OuterMarginSize); } }

        public int WindowRadious
        {
            get
            {
                return _window.WindowState == WindowState.Maximized ? 0 : _windowRadious;
            }
            set
            {
                _windowRadious = value;
            }
        }

        public CornerRadius WindowCornerRadious { get { return new CornerRadius(WindowRadious); } }

        public int TitleHeight { get; set; } = 32;

        public GridLength TitleHeightGrigLength { get { return new GridLength(TitleHeight + ResizeBoarder); } }
        #endregion
        #region ctor
        public WindowViewModel(Window window)
        {
            _window = window;

            _window.SizeChanged += (sender, e) =>
            {
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginSizeThickness));
                OnPropertyChanged(nameof(WindowRadious));
                OnPropertyChanged(nameof(WindowCornerRadious));
            };

        }
        #endregion
    }
}
