

using System.Windows;
using System.Windows.Input;

namespace WpfLearningProject2.ViewModel
{
    public class WindowViewModel : BaseViewModel
    {
        private Window _window;
        private int _outerMarginSize = 10;
        private int _windowRadious = 10;


        #region Public Memeber

        public int WindowMinimumWidth { get; set; } = 400;

        public int WindowMinimumHeight { get; set; } = 400;

        /// <summary>
        /// The resize boarder thickness
        /// </summary>
        public int ResizeBoarder { get; set; } = 5;

        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBoarder + OuterMarginSize); }}

        public Thickness InnerContentPadding { get { return new Thickness(ResizeBoarder); } }

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
        #region Command
        public ICommand MaximizeCommand { get; set; }
        public ICommand MinimizeCoammand { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand MenuCommand { get; set; }
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

            MinimizeCoammand = new RelayCommand(() => { _window.WindowState = WindowState.Minimized; });
            MaximizeCommand = new RelayCommand(() => { _window.WindowState ^= WindowState.Maximized; });
            CloseCommand = new RelayCommand(() => _window.Close());
            MenuCommand = new RelayCommand(() => {
                SystemCommands.ShowSystemMenu(_window, _window.PointToScreen(Mouse.GetPosition(_window)));
            });

            // Fix window resize issue
            var resizer = new WindowResizer(_window); 

        }
        #endregion
    }
}
