

using System.Windows;
using System.Windows.Input;
using WpfLearningProject2.DataModels;

namespace WpfLearningProject2.ViewModel
{
    public class WindowViewModel : BaseViewModel
    {
        #region Private Member
        private Window _window;
        private int _outerMarginSize = 10;
        private int _windowRadious = 10;
        #endregion


        #region Public Memeber

        public int WindowMinimumWidth { get; set; } = 400;

        public int WindowMinimumHeight { get; set; } = 400;

        public bool Borderless { get { return (_window.WindowState == WindowState.Maximized); } }

        /// <summary>
        /// The resize boarder thickness
        /// </summary>
        public int ResizeBoarder { get { return Borderless ? 0 : 5; } }

        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBoarder + OuterMarginSize); }}

        public Thickness InnerContentPadding { get; set; } = new Thickness(0);

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

        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Login;
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
