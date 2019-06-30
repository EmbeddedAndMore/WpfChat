using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace WpfLearningProject2
{
    public enum WindowDockPosition
    {
        /// <summary>
        /// Not docked
        /// </summary>
        Undocked = 0,
        /// <summary>
        /// Docked to the left of the screen
        /// </summary>
        Left = 1,
        /// <summary>
        /// Docked to the right of the screen
        /// </summary>
        Right = 2,
        /// <summary>
        /// Docked to the top/bottom of the screen
        /// </summary>
        TopBottom = 3,
        /// <summary>
        /// Docked to the top-left of the screen
        /// </summary>
        TopLeft = 4,
        /// <summary>
        /// Docked to the top-right of the screen
        /// </summary>
        TopRight = 5,
        /// <summary>
        /// Docked to the bottom-left of the screen
        /// </summary>
        BottomLeft = 6,
        /// <summary>
        /// Docked to the bottom-right of the screen
        /// </summary>
        BottomRight = 7,
    }
    /// <summary>
    /// Fixes the issue with Windows of Style <see cref="WindowStyle.None"/> covering the taskbar
    /// </summary>
    public class WindowResizer
    {
        #region Private Members

        /// <summary>
        /// The window to handle the resizing for
        /// </summary>
        private Window mWindow;

        /// <summary>
        /// The last calculated available screen size
        /// </summary>
        private Rect mScreenSize = new Rect();

        /// <summary>
        /// How close to the edge the window has to be to be detected as at the edge of the screen
        /// </summary>
        private int mEdgeTolerance = 1;


        /// <summary>
        /// The last screen the window was on
        /// </summary>
        private IntPtr mLastScreen;

        /// <summary>
        /// The last known dock position
        /// </summary>
        private WindowDockPosition mLastDock = WindowDockPosition.Undocked;

        /// <summary>
        /// A flag indicating if the window is currently being moved/dragged
        /// </summary>
        private bool mBeingMoved = false;
        #endregion

        #region Dll Imports

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetCursorPos(out POINT lpPoint);

        [DllImport("user32.dll")]
        static extern bool GetMonitorInfo(IntPtr hMonitor, MONITORINFO lpmi);

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr MonitorFromPoint(POINT pt, MonitorOptions dwFlags);

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="window">The window to monitor and correctly maximize</param>
        /// <param name="adjustSize">The callback for the host to adjust the maximum available size if needed</param>
        public WindowResizer(Window window)
        {
            mWindow = window;

            // Listen out for source initialized to setup
            mWindow.SourceInitialized += Window_SourceInitialized;

            // Monitor for edge docking
            //mWindow.SizeChanged += Window_SizeChanged;
            mWindow.LocationChanged += Window_LocationChanged;
        }

        #endregion

        #region Initialize

        /// <summary>
        /// Initialize and hook into the windows message pump
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_SourceInitialized(object sender, System.EventArgs e)
        {
            // Get the handle of this window
            var handle = (new WindowInteropHelper(mWindow)).Handle;
            var handleSource = HwndSource.FromHwnd(handle);

            // If not found, end
            if (handleSource == null)
                return;

            // Hook into it's Windows messages
            handleSource.AddHook(WindowProc);
        }

        #endregion

        #region Windows Proc

        /// <summary>
        /// Listens out for all windows messages for this window
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <param name="handled"></param>
        /// <returns></returns>
        private IntPtr WindowProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            switch (msg)
            {
                // Handle the GetMinMaxInfo of the Window
                case 0x0024:/* WM_GETMINMAXINFO */
                    WmGetMinMaxInfo(hwnd, lParam);
                    handled = true;
                    break;
            }

            return (IntPtr)0;
        }

        #endregion

        /// <summary>
        /// Get the min/max window size for this window
        /// Correctly accounting for the taskbar size and position
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="lParam"></param>
        private void WmGetMinMaxInfo(System.IntPtr hwnd, System.IntPtr lParam)
        {
            POINT lMousePosition;
            GetCursorPos(out lMousePosition);

            IntPtr lPrimaryScreen = MonitorFromPoint(new POINT(0, 0), MonitorOptions.MONITOR_DEFAULTTOPRIMARY);
            MONITORINFO lPrimaryScreenInfo = new MONITORINFO();
            if (GetMonitorInfo(lPrimaryScreen, lPrimaryScreenInfo) == false)
            {
                return;
            }

            IntPtr lCurrentScreen = MonitorFromPoint(lMousePosition, MonitorOptions.MONITOR_DEFAULTTONEAREST);

            MINMAXINFO lMmi = (MINMAXINFO)Marshal.PtrToStructure(lParam, typeof(MINMAXINFO));

            if (lPrimaryScreen.Equals(lCurrentScreen) == true)
            {
                lMmi.ptMaxPosition.X = lPrimaryScreenInfo.rcWork.Left;
                lMmi.ptMaxPosition.Y = lPrimaryScreenInfo.rcWork.Top;
                lMmi.ptMaxSize.X = lPrimaryScreenInfo.rcWork.Right - lPrimaryScreenInfo.rcWork.Left;
                lMmi.ptMaxSize.Y = lPrimaryScreenInfo.rcWork.Bottom - lPrimaryScreenInfo.rcWork.Top;
            }
            else
            {
                lMmi.ptMaxPosition.X = lPrimaryScreenInfo.rcMonitor.Left;
                lMmi.ptMaxPosition.Y = lPrimaryScreenInfo.rcMonitor.Top;
                lMmi.ptMaxSize.X = lPrimaryScreenInfo.rcMonitor.Right - lPrimaryScreenInfo.rcMonitor.Left;
                lMmi.ptMaxSize.Y = lPrimaryScreenInfo.rcMonitor.Bottom - lPrimaryScreenInfo.rcMonitor.Top;
            }

            // Now we have the max size, allow the host to tweak as needed
            Marshal.StructureToPtr(lMmi, lParam, true);
        }


        /// <summary>
        /// Monitor for moving of the window and constantly check for docked positions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_LocationChanged(object sender, EventArgs e)
        {
            //Window_SizeChanged(null, null);
        }

        /// <summary>
        /// Monitors for size changes and detects if the window has been docked (Aero snap) to an edge
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        //{
        //    // Make sure our monitor info is up-to-date
        //    WmGetMinMaxInfo(IntPtr.Zero, IntPtr.Zero);

        //    // Get the monitor transform for the current position
        //    mMonitorDpi = VisualTreeHelper.GetDpi(mWindow);

        //    // Cannot calculate size until we know monitor scale
        //    if (mMonitorDpi == null)
        //        return;

        //    // Get window rectangle
        //    var top = mWindow.Top;
        //    var left = mWindow.Left;
        //    var bottom = top + mWindow.Height;
        //    var right = left + mWindow.Width;

        //    // Get window position/size in device pixels
        //    var windowTopLeft = new Point(left * mMonitorDpi.Value.DpiScaleX, top * mMonitorDpi.Value.DpiScaleX);
        //    var windowBottomRight = new Point(right * mMonitorDpi.Value.DpiScaleX, bottom * mMonitorDpi.Value.DpiScaleX);

        //    // Check for edges docked
        //    var edgedTop = windowTopLeft.Y <= (mScreenSize.Top + mEdgeTolerance) && windowTopLeft.Y >= (mScreenSize.Top - mEdgeTolerance);
        //    var edgedLeft = windowTopLeft.X <= (mScreenSize.Left + mEdgeTolerance) && windowTopLeft.X >= (mScreenSize.Left - mEdgeTolerance);
        //    var edgedBottom = windowBottomRight.Y >= (mScreenSize.Bottom - mEdgeTolerance) && windowBottomRight.Y <= (mScreenSize.Bottom + mEdgeTolerance);
        //    var edgedRight = windowBottomRight.X >= (mScreenSize.Right - mEdgeTolerance) && windowBottomRight.X <= (mScreenSize.Right + mEdgeTolerance);

        //    // Get docked position
        //    var dock = WindowDockPosition.Undocked;

        //    // Left docking
        //    if (edgedTop && edgedBottom && edgedLeft)
        //        dock = WindowDockPosition.Left;
        //    // Right docking
        //    else if (edgedTop && edgedBottom && edgedRight)
        //        dock = WindowDockPosition.Right;
        //    // Top/bottom
        //    else if (edgedTop && edgedBottom)
        //        dock = WindowDockPosition.TopBottom;
        //    // Top-left
        //    else if (edgedTop && edgedLeft)
        //        dock = WindowDockPosition.TopLeft;
        //    // Top-right
        //    else if (edgedTop && edgedRight)
        //        dock = WindowDockPosition.TopRight;
        //    // Bottom-left
        //    else if (edgedBottom && edgedLeft)
        //        dock = WindowDockPosition.BottomLeft;
        //    // Bottom-right
        //    else if (edgedBottom && edgedRight)
        //        dock = WindowDockPosition.BottomRight;

        //    // None
        //    else
        //        dock = WindowDockPosition.Undocked;

        //    // If dock has changed
        //    if (dock != mLastDock)
        //        // Inform listeners
        //        WindowDockChanged(dock);

        //    // Save last dock position
        //    mLastDock = dock;
        //}
    }

    #region Dll Helper Structures

    enum MonitorOptions : uint
    {
        MONITOR_DEFAULTTONULL = 0x00000000,
        MONITOR_DEFAULTTOPRIMARY = 0x00000001,
        MONITOR_DEFAULTTONEAREST = 0x00000002
    }


    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public class MONITORINFO
    {
        public int cbSize = Marshal.SizeOf(typeof(MONITORINFO));
        public Rectangle rcMonitor = new Rectangle();
        public Rectangle rcWork = new Rectangle();
        public int dwFlags = 0;
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct Rectangle
    {
        public int Left, Top, Right, Bottom;

        public Rectangle(int left, int top, int right, int bottom)
        {
            this.Left = left;
            this.Top = top;
            this.Right = right;
            this.Bottom = bottom;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MINMAXINFO
    {
        public POINT ptReserved;
        public POINT ptMaxSize;
        public POINT ptMaxPosition;
        public POINT ptMinTrackSize;
        public POINT ptMaxTrackSize;
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        /// <summary>
        /// x coordinate of point.
        /// </summary>
        public int X;
        /// <summary>
        /// y coordinate of point.
        /// </summary>
        public int Y;

        /// <summary>
        /// Construct a point of coordinates (x,y).
        /// </summary>
        public POINT(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }

    #endregion
}