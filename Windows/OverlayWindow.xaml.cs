using Microsoft.Win32;
using SimpleTimers.Controls;
using SimpleTimers.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SimpleTimers.Windows
{
    /// <summary>
    /// Interaction logic for OverlayWindow.xaml
    /// </summary>
    public partial class OverlayWindow : Window
    {
        [DllImport("user32.dll")]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        private const int GWL_EXSTYLE = -20;
        private const int WS_EX_TRANSPARENT = 0x00000020;
        private const int WS_EX_LAYERED = 0x00080000;

        private int _imageIndex = 0;
        private bool _isVisible = true;
        private bool _showOverlayImageNumber = true;

        private List<string> _imageList;

        void Window_Loaded(object sender, RoutedEventArgs e)
        {
            IntPtr hwnd = new WindowInteropHelper(this).Handle;
            SetWindowLong(hwnd, GWL_EXSTYLE,
                GetWindowLong(hwnd, GWL_EXSTYLE) | WS_EX_TRANSPARENT | WS_EX_LAYERED);

            LoadSettings();
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Get the primary monitor's dimensions.
            var primaryScreenWidth = SystemParameters.PrimaryScreenWidth;
            var primaryScreenHeight = SystemParameters.PrimaryScreenHeight;

            // Get the virtual screen dimensions, which spans all monitors.
            var virtualScreenWidth = SystemParameters.VirtualScreenWidth;
            var virtualScreenHeight = SystemParameters.VirtualScreenHeight;

            // Determine if there is more than one screen.
            if (virtualScreenWidth > primaryScreenWidth || virtualScreenHeight > primaryScreenHeight)
            {
                // Here we assume the secondary monitor is to the right of the primary.
                // You may need to adjust this logic to handle different monitor positions.
                var secondaryScreenLeft = primaryScreenWidth;
                var secondaryScreenTop = 0; // Change this if the secondary monitor is not aligned to the top of the primary monitor.

                // Set the position of the window to the secondary monitor.
                Left = secondaryScreenLeft;
                Top = secondaryScreenTop;
            }
        }

        public OverlayWindow(List<string> imageList, bool showOverlayImageNumber)
        {
            _imageList = imageList;
            _showOverlayImageNumber = showOverlayImageNumber;
            InitializeComponent();
            Loaded += new RoutedEventHandler(Window_Loaded);

            ShowImage();
        }

        private void LoadSettings()
        {
            var settings = Properties.Settings.Default;
            gameTimer1.Duration = settings.Timer1Duration;
            gameTimer2.Duration = settings.Timer2Duration;
            gameTimer3.Duration = settings.Timer3Duration;
            gameTimer4.Duration = settings.Timer4Duration;
            gameTimer5.Duration = settings.Timer5Duration;
            gameTimer6.Duration = settings.Timer6Duration;
            gameTimer1.Text = settings.Timer1Label;
            gameTimer2.Text = settings.Timer2Label;
            gameTimer3.Text = settings.Timer3Label;
            gameTimer4.Text = settings.Timer4Label;
            gameTimer5.Text = settings.Timer5Label;
            gameTimer6.Text = settings.Timer6Label;
        }

        public void NextImage()
        {
            _imageIndex++;
            if (_imageIndex >= _imageList.Count)
            {
                _imageIndex = _imageList.Count - 1;
            }

            ShowImage();
        }

        public void PreviousImage()
        {
            _imageIndex--;
            if (_imageIndex < 0)
            {
                _imageIndex = 0;
            }

            ShowImage();
        }

        private void ShowImage()
        {
            if (_imageList.Count > 0 && _imageIndex < _imageList.Count && _imageIndex >= 0)
            {
                try
                {

                    imageDisplay.Source = new BitmapImage(new Uri(_imageList[_imageIndex]));
                    errorLabel.Visibility = Visibility.Hidden;
                }
                catch (Exception e)
                {
                    errorLabel.Text = "Error loading image " + _imageList[_imageIndex] + ": " + e.Message;
                    errorLabel.Visibility = Visibility.Visible;
                }
                imageNumberLabel.Content = (_imageIndex + 1).ToString();
            }
            imageDisplay.Visibility = Visibility.Visible;
            imageNumberLabel.Visibility = _showOverlayImageNumber ? Visibility.Visible : Visibility.Hidden;
        }

        public void HideImage()
        {
            imageDisplay.Visibility = Visibility.Hidden;
            imageNumberLabel.Visibility = Visibility.Hidden;
        }

        public void ToggleImage()
        {
            _isVisible = !_isVisible;
            if (_isVisible)
            {
                ShowImage();
            }
            else
            {
                HideImage();
            }
        }

        public void StartTimer1()
        {
            gameTimer1.Visibility = Visibility.Visible;
            gameTimer1.StartTimer();
        }

        public void StartTimer2()
        {
            gameTimer2.Visibility = Visibility.Visible;
            gameTimer2.StartTimer();
        }

        public void StartTimer3()
        {
            gameTimer3.Visibility = Visibility.Visible;
            gameTimer3.StartTimer();
        }

        public void StartTimer4()
        {
            gameTimer4.Visibility = Visibility.Visible;
            gameTimer4.StartTimer();
        }

        public void StartTimer5()
        {
            gameTimer5.Visibility = Visibility.Visible;
            gameTimer5.StartTimer();
        }

        public void StartTimer6()
        {
            gameTimer6.Visibility = Visibility.Visible;
            gameTimer6.StartTimer();
        }
    }
}
