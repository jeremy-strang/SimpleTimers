using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
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
using System.Windows.Threading;

namespace SimpleTimers.Controls
{
    /// <summary>
    /// Interaction logic for PartialScreenView.xaml
    /// </summary>
    public partial class PartialScreenView : UserControl
    {
        private DispatcherTimer _timer;
        // Define the area of the screen you want to capture
        public int CaptureX { get; set; } // X coordinate of the top-left corner of the capture area 1610
        public int CaptureY { get; set; } // Y coordinate of the top-left corner of the capture area 1180
        public int CaptureWidth { get; set; } // Width of the capture area
        public int CaptureHeight { get; set; } // Height of the capture area

        public PartialScreenView()
        {
            InitializeComponent();

            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(33); // Update every 100ms
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            CapturedImage.Source = CaptureScreenArea(CaptureX, CaptureY, CaptureWidth, CaptureHeight);
        }

        private BitmapSource CaptureScreenArea(int x, int y, int width, int height)
        {
            using (Bitmap bmp = new Bitmap(width, height))
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.CopyFromScreen(x, y, 0, 0, bmp.Size);
                }
                IntPtr hBitmap = bmp.GetHbitmap();
                BitmapSource result = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                    hBitmap, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                // Delete the HBitmap to avoid memory leaks
                DeleteObject(hBitmap);
                return result;
            }
        }

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
    }
}
